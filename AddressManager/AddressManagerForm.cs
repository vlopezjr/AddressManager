using CPUserControls.AddressModule;
using CPUserControls.Services;
using CreateCustomer.API.DomainServices;
using CreateCustomer.API.Entities;
using CreateCustomer.API.Enums;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AddressManager
{
    public partial class AddressManagerForm : Form
    {
        public event Action AddressUpdatedOrAdded = delegate { };

        private Customer customer = new Customer();

        private BLAddress currentAddress;
        private CustAddress currentCustAddress;
        private CustomerService service;

        private BLAddress cachedAddress;
        private CustAddress cachedCustAddr;

        private List<BLAddress> allAddresses;
        private List<BLAddress> activeAddresses;
        private List<BLAddress> deletedAddresses;

        private AddressControl addressControl;
        private AddressDataGridView addressDataGridView;

        private int custKey;
        private bool isInPamsGroup;
        private string userName;


        public AddressManagerForm()
        {
            InitializeComponent();
        }


        public void Initialize(int _custKey, CustomerService _service)
        {
            SetUserPermissions();

            currentAddress = new BLAddress(new TaxService(), new ValidationService());
            currentCustAddress = new CustAddress();
            service = _service;

            custKey = _custKey;
        }

        private void SetUserPermissions()
        {
            isInPamsGroup = false;

            userName = Environment.UserName;

            var context = new PrincipalContext(ContextType.Domain, "caseparts");
            var custCreateGroup = GroupPrincipal.FindByIdentity(context, "CustCreation");
            var devGroup = GroupPrincipal.FindByIdentity(context, "Developers");

            var user = UserPrincipal.FindByIdentity(context, userName);

            if (user != null)
            {
                if (user.IsMemberOf(devGroup))
                {
                    isInPamsGroup = true;
                }
                else
                {
                    isInPamsGroup = custCreateGroup != null ? user.IsMemberOf(custCreateGroup) : false;
                }
            }

            if (custCreateGroup == null)
            {
                statusLabel.Text = "Failed to set permissions. Contact IT if this problem persist.";
                statusLabel.ForeColor = Color.Red;
            }


            context.Dispose();

            if (custCreateGroup != null)
                custCreateGroup.Dispose();
        }






        private void AddressManagerForm_Load(object sender, EventArgs e)
        {
            SetControlVisibilityBasedOnPermissions();
            LoadCustomerAndSetUpList();
            SetCurrentAddressFromSelectedRow();
            SetCustomerLabel();
            SetCountLabel();
            SetUpAddressEditorControl();
            SetUpAddressDGVControl();
            SetFormToCurrentAddress();
            CenterAccountLabel();

            statusLabel.Text = "Permissions set for " + userName;
            statusLabel.ForeColor = Color.Green;
        }

        private void SetControlVisibilityBasedOnPermissions()
        {
            if (!isInPamsGroup)
            {
                grpAccountType.Visible = false;
                chkShowDeleted.Visible = false;
                grpStatus.Visible = false;
            }
            else
            {
                grpAccountType.Enabled = true;
                chkShowDeleted.Visible = true;
                grpStatus.Visible = true;
            }
        }

        private void SetCountLabel()
        {
            var currentList = GetCurrentList();
            lblCount.Text = "Count: " + currentList.Count.ToString();
            lblCount.ForeColor = currentList.Count > 0 ? Color.Green : Color.Red;
        }


        private void CenterAccountLabel()
        {
            var halfWidth = Width / 2;
            var count = lblAccount.Text.Length;
            var left = count * 3;
            lblAccount.Location = new Point(halfWidth - left, lblAccount.Location.Y);
        }

        private void SetCustomerLabel()
        {
            lblAccount.Text = customer.Name + "(" + (customer.IsHQ ? "HQ" : "Branch") + ")";
            if (customer.IsStandAlone)
                lblAccount.Text = customer.Name;
        }

        private void LoadCustomerAndSetUpList()
        {
            customer = service.LoadCustomerWithDependenciesByKey(custKey);

            allAddresses = new List<BLAddress>();
            foreach (var custAddr in customer.CustAddresses)
            {
                allAddresses.Add(new BLAddress
                {
                    Data = custAddr.Address,
                    SalesTaxKey = custAddr.STaxSchdKey ?? 0,
                    IsValidated = true
                });
            }

            allAddresses.ForEach(addr => addr.SplitZipCode());

            QualifyAddresses();

            allAddresses = allAddresses
                .OrderByDescending(i => i.IsPrimaryAddress)
                .ThenByDescending(o => o.IsDefaultShipping)
                .ThenByDescending(p => p.Data.Name)
                .ToList();

            SeparateActiveAndInactive(allAddresses);
        }

        private void SeparateActiveAndInactive(List<BLAddress> allAddresses)
        {
            activeAddresses = allAddresses.Where(c => c.Data.CustAddress.ShipDays < 90).ToList();
            deletedAddresses = allAddresses.Where(addr => addr.Data.CustAddress.ShipDays > 90).ToList();
        }




        ///ADDRESS DATAGRIDVIEW CONTROL
        private void SetUpAddressDGVControl()
        {
            addressDataGridView = new AddressDataGridView() { Dock = DockStyle.Fill };
            addressDataGridView.ShowActiveColumn();
            addressDataGridView.Initialize(activeAddresses);
            addressDataGridView.SelectionChanged += (key) =>
            {
                bool proceed = NotifyIfAddressIsDirty();
                if (proceed)
                {
                    cachedAddrKeyForRowSelection = key;

                    currentAddress = allAddresses.First(addr => addr.Data.Key == key);
                    currentCustAddress = customer.CustAddresses.First(c => c.Key == key);

                    SetFormToCurrentAddress();
                    CacheCurrentAddress();
                    CacheCustAddress();

                    btnSave.Enabled = false;
                    statusLabel.Text = "";
                }
            };

            panelDGV.Controls.Add(addressDataGridView);
        }






        //ADDRESS CONTROL
        private void SetUpAddressEditorControl()
        {
            addressControl = new AddressControl { Dock = DockStyle.Fill };
            addressControl.HideStatus();
            addressControl.HideCustId();
            addressControl.StatusChanged += AddressControl_StatusChanged;
            addressControl.Done += AddressControl_Done;
            addressControl.Invalid += AddressControl_Invalid;
            addressControl.EnterPressed += AddressControl_EnterPressed;
            addressControl.CustKey = customer.Key;

            panelAddress.Controls.Add(addressControl);
        }

        private void AddressControl_EnterPressed()
        {
            btnSave.PerformClick();
        }

        private void AddressControl_Invalid()
        {
            currentAddress.IsValidated = false;
            currentAddress.IsDirty = true;
            btnSave.Enabled = false;
        }


        private void AddressControl_Done(BLAddress address)
        {
            if (address.IsDirty)
            {
                btnSave.Enabled = true;

                currentAddress.IsDirty = address.IsDirty;
                currentAddress.IsValidated = address.IsValidated;

                currentAddress.Data.Name = address.Data.Name;
                currentAddress.Data.Line1 = address.Data.Line1;
                currentAddress.Data.Line2 = address.Data.Line2;
                currentAddress.Data.City = address.Data.City;
                currentAddress.Data.State = address.Data.State;
                currentAddress.Data.Zip = address.Data.Zip;
                currentAddress.Data.Country = address.Data.Country;
                currentAddress.Data.Residential = address.Data.Residential;

                RemoveNullsOnEmptyAddressProperties();

                var custAddr = customer.CustAddresses.FirstOrDefault(c => c.Key == currentAddress.Data.Key);
                var primaryCustAddr = customer.CustAddresses.FirstOrDefault(c => c.Key == customer.PrimaryAddrKey);
                var whseTerr = GetWarehouseAndTerritory(currentAddress.Data.State);

                if (custAddr == null) //new entry
                {
                    custAddr = new CustAddress();
                    MapCustAddr(ref custAddr, primaryCustAddr);

                    custAddr.WhseKey = whseTerr.Item1;
                    custAddr.SalesTerritoryKey = whseTerr.Item2;
                    custAddr.Key = address.Data.Key;
                    custAddr.STaxSchdKey = address.SalesTaxKey;
                    custAddr.CreateDate = DateTime.Now;
                    custAddr.CreateUserID = userName;
                    custAddr.UpdateDate = null;
                    custAddr.UpdateUserID = null;
                    custAddr.Type = CustAddrType.CSA;

                    currentCustAddress = custAddr;
                }
                else //existing entry - doing update
                {
                    MapCustAddr(ref custAddr, primaryCustAddr);

                    custAddr.WhseKey = whseTerr.Item1;
                    custAddr.SalesTerritoryKey = whseTerr.Item2;
                    custAddr.STaxSchdKey = address.SalesTaxKey;
                    custAddr.UpdateDate = DateTime.Now;
                    custAddr.UpdateUserID = userName;
                    custAddr.Type = CustAddrType.CSA;
                }

                SetTaxRateTextBox();
            }
        }

        private void AddressControl_StatusChanged(Color statusColor, string statusMessage)
        {
            statusLabel.ForeColor = statusColor;
            statusLabel.Text = statusMessage;
        }




        private Tuple<int, int> GetWarehouseAndTerritory(string state)
        {
            var lookupService = new LookUpService();
            var branchID = lookupService.GetBranchIDByState(state);
            var warehouses = lookupService.GetBranches();

            var whseKey = warehouses.FirstOrDefault(wh => wh.BranchID == branchID).Key;
            var salesTerritoryKey = warehouses.FirstOrDefault(wh => wh.BranchID == branchID).SalesTerritoryKey;

            return new Tuple<int, int>(whseKey, salesTerritoryKey);
        }




        #region SET ADDRESS AND CUSTADDRESS FIELDS
        private void QualifyAddresses()
        {
            foreach (var addr in allAddresses)
            {
                string type = addr.Type == null ? "" : addr.Type;

                if (customer != null && string.IsNullOrEmpty(type))
                {
                    if (addr.Data.Key == customer.DfltShipToAddrKey)
                    {
                        type = type.Insert(0, "Ship");
                        addr.IsDefaultShipping = true;
                    }
                    else
                        addr.IsDefaultShipping = false;

                    if (addr.Data.Key == customer.PrimaryAddrKey)
                    {
                        type = type.Insert(0, "Bill");
                        addr.IsPrimaryAddress = true;
                    }
                    else
                        addr.IsPrimaryAddress = false;

                    if (type.Length == 0)
                    {
                        type = "CSA";
                    }

                    addr.Type = type;
                }
            }
        }

        private void SetFormToCurrentAddress()
        {
            if (currentAddress == null) return;
            if (currentAddress.Data == null) return;

            addressControl.AddrName = currentAddress.Data.Name;
            addressControl.Line1 = currentAddress.Data.Line1;
            addressControl.Line2 = currentAddress.Data.Line2;
            addressControl.City = currentAddress.Data.City;
            addressControl.State = currentAddress.Data.State;
            addressControl.ZipCode = currentAddress.Data.Zip;
            addressControl.Country = currentAddress.Data.Country;
            addressControl.TaxKey = currentAddress.SalesTaxKey;
            addressControl.Residential = currentAddress.Data.Residential;
            addressControl.Refresh();

            UnsubscribeFromCheckChanged();
            chkPrimaryBilling.Checked = currentAddress.IsPrimaryAddress;
            chkShipping.Checked = currentAddress.IsDefaultShipping;
            chkCommon.Checked = !currentAddress.IsDefaultShipping && !currentAddress.IsPrimaryAddress;
            rdoActive.Checked = currentCustAddress.ShipDays < 90;
            rdoDeleted.Checked = !rdoActive.Checked;
            SubscribeToCheckChanged();

            SetTaxRateTextBox(); 

            rdoActive.Enabled = true;
            rdoDeleted.Enabled = true;

            if (currentAddress.IsPrimaryAddress)
            {
                grpStatus.Enabled = false;
            }
            else
            {
                grpStatus.Enabled = true;
            }

            if (currentCustAddress.ShipDays > 90) //if deleted
            {
                grpAccountType.Enabled = false;
            }
            else
            {
                grpAccountType.Enabled = true;
            }
        }

        private void SetTaxRateTextBox()
        {
            if(currentCustAddress.TaxSchedule == null)
            {
                var lookup = new LookUpService();
                if(currentCustAddress.STaxSchdKey != null)
                {
                    var schdKey = (int)currentCustAddress.STaxSchdKey;

                    var taxSchedule = lookup.GetTaxScheduleByKey(schdKey);
                    txtTaxRate.Text = string.Format("{0:G29} %", taxSchedule.Rate);
                }
                else
                {
                    txtTaxRate.Text = string.Format("0.0 %");
                }
            }
            else
            {
                var taxSchedule = currentCustAddress.TaxSchedule;
                txtTaxRate.Text = string.Format("{0:G29} %", taxSchedule.Rate);
            }
        }

        private void MapCustAddr(ref CustAddress dst, CustAddress src)
        {
            dst.PmtTermsKey = src.PmtTermsKey;
            dst.ShipMethKey = src.ShipMethKey;
            dst.InvcFormKey = src.InvcFormKey;
            dst.PackListFormKey = src.PackListFormKey;

            dst.AllowInvtSubst = src.AllowInvtSubst;
            dst.CurrID = src.CurrID;
            dst.FOBKey = src.FOBKey;
            dst.LanguageID = src.LanguageID;
            dst.RequireSOAck = src.RequireSOAck;
            dst.ShipComplete = src.ShipComplete;
            dst.ShipLabelFormKey = src.ShipLabelFormKey;
            dst.SOAckFormKey = src.SOAckFormKey;
            dst.SperKey = src.SperKey;

            dst.BackOrdPrice = src.BackOrdPrice;
            dst.BOLReqd = src.BOLReqd;
            dst.CarrierAcctNo = src.CarrierAcctNo;
            dst.CarrierBillMeth = src.CarrierBillMeth;
            dst.CloseSOLineOnFirstShip = src.CloseSOLineOnFirstShip;
            dst.CloseSOOnFirstShip = src.CloseSOOnFirstShip;
            dst.CreateDate = src.CreateDate;
            dst.CreateType = src.CreateType;
            dst.CreateUserID = src.CreateUserID;
            dst.FreightMethod = src.FreightMethod;
            dst.InvcMsg = src.InvcMsg;
            dst.InvoiceReqd = src.InvoiceReqd;
            dst.InvcFormKey = src.InvcFormKey;
            dst.PackListContentsReqd = src.PackListContentsReqd;
            dst.PackListReqd = src.PackListReqd;
            dst.PriceAdj = src.PriceAdj;
            dst.PriceBase = src.PriceBase;
            dst.PrintOrderAck = src.PrintOrderAck;
            dst.ShipLabelsReqd = src.ShipLabelsReqd;
            dst.SOAckMeth = src.SOAckMeth;
            dst.UsePromoPrice = src.UsePromoPrice;
        }

        private void RemoveNullsOnEmptyAddressProperties()
        {
            currentAddress.Data.Line2 = currentAddress.Data.Line2 ?? "";
            currentAddress.Data.Line3 = currentAddress.Data.Line3 ?? "";
            currentAddress.Data.Line4 = currentAddress.Data.Line4 ?? "";
            currentAddress.Data.Line5 = currentAddress.Data.Line5 ?? "";
            currentAddress.Data.Phone = currentAddress.Data.Phone ?? "";
            currentAddress.Data.PhoneExt = currentAddress.Data.PhoneExt ?? "";
            currentAddress.Data.MobilePhone = currentAddress.Data.MobilePhone ?? "";

            currentAddress.Data.TransactionOverride = 0;
            if (currentAddress.IsNew)
                currentAddress.Data.UpdateCounter = 0;
            else
                currentAddress.Data.UpdateCounter = currentAddress.Data.UpdateCounter + 1;
        }

        private void CacheCurrentAddress()
        {
            cachedAddress = new BLAddress();
            cachedAddress.Data = new Address();

            cachedAddress.Data.Key = currentAddress.Data.Key;
            cachedAddress.SalesTaxKey = currentAddress.SalesTaxKey;
            cachedAddress.Zip5 = currentAddress.Zip5;
            cachedAddress.Zip4 = currentAddress.Zip4;
            cachedAddress.Type = currentAddress.Type;
            cachedAddress.Data.Name = currentAddress.Data.Name;
            cachedAddress.Data.Line1 = currentAddress.Data.Line1;
            cachedAddress.Data.Line2 = currentAddress.Data.Line2;
            cachedAddress.Data.City = currentAddress.Data.City;
            cachedAddress.Data.State = currentAddress.Data.State;
            cachedAddress.Data.Zip = currentAddress.Data.Zip;
            cachedAddress.Data.Residential = currentAddress.Data.Residential;
        }

        private void CacheCustAddress()
        {
            var currentCustAddr = customer.CustAddresses.First(c => c.Key == currentAddress.Data.Key);

            cachedCustAddr = new CustAddress();

            cachedCustAddr.WhseKey = currentCustAddr.WhseKey;
            cachedCustAddr.SalesTerritoryKey = currentCustAddr.SalesTerritoryKey;
            cachedCustAddr.STaxSchdKey = currentCustAddr.STaxSchdKey;
            cachedCustAddr.UpdateDate = currentCustAddr.UpdateDate;
            cachedCustAddr.UpdateUserID = currentCustAddr.UpdateUserID;
            cachedCustAddr.Type = currentCustAddr.Type;

            cachedCustAddr.PmtTermsKey = currentCustAddr.PmtTermsKey;
            cachedCustAddr.ShipMethKey = currentCustAddr.ShipMethKey;
            cachedCustAddr.InvcFormKey = currentCustAddr.InvcFormKey;
            cachedCustAddr.PackListFormKey = currentCustAddr.PackListFormKey;

            cachedCustAddr.AllowInvtSubst = currentCustAddr.AllowInvtSubst;
            cachedCustAddr.CurrID = currentCustAddr.CurrID;
            cachedCustAddr.FOBKey = currentCustAddr.FOBKey;
            cachedCustAddr.LanguageID = currentCustAddr.LanguageID;
            cachedCustAddr.RequireSOAck = currentCustAddr.RequireSOAck;
            cachedCustAddr.ShipComplete = currentCustAddr.ShipComplete;
            cachedCustAddr.ShipLabelFormKey = currentCustAddr.ShipLabelFormKey;
            cachedCustAddr.SOAckFormKey = currentCustAddr.SOAckFormKey;
            cachedCustAddr.SperKey = currentCustAddr.SperKey;

            cachedCustAddr.BackOrdPrice = currentCustAddr.BackOrdPrice;
            cachedCustAddr.BOLReqd = currentCustAddr.BOLReqd;
            cachedCustAddr.CarrierAcctNo = currentCustAddr.CarrierAcctNo;
            cachedCustAddr.CarrierBillMeth = currentCustAddr.CarrierBillMeth;
            cachedCustAddr.CloseSOLineOnFirstShip = currentCustAddr.CloseSOLineOnFirstShip;
            cachedCustAddr.CloseSOOnFirstShip = currentCustAddr.CloseSOOnFirstShip;
            cachedCustAddr.CreateDate = currentCustAddr.CreateDate;
            cachedCustAddr.CreateType = currentCustAddr.CreateType;
            cachedCustAddr.CreateUserID = currentCustAddr.CreateUserID;
            cachedCustAddr.FreightMethod = currentCustAddr.FreightMethod;
            cachedCustAddr.InvcMsg = currentCustAddr.InvcMsg;
            cachedCustAddr.InvoiceReqd = currentCustAddr.InvoiceReqd;
            cachedCustAddr.InvcFormKey = currentCustAddr.InvcFormKey;
            cachedCustAddr.PackListContentsReqd = currentCustAddr.PackListContentsReqd;
            cachedCustAddr.PackListReqd = currentCustAddr.PackListReqd;
            cachedCustAddr.PriceAdj = currentCustAddr.PriceAdj;
            cachedCustAddr.PriceBase = currentCustAddr.PriceBase;
            cachedCustAddr.PrintOrderAck = currentCustAddr.PrintOrderAck;
            cachedCustAddr.ShipDays = currentCustAddr.ShipDays;
            cachedCustAddr.ShipLabelsReqd = currentCustAddr.ShipLabelsReqd;
            cachedCustAddr.SOAckMeth = currentCustAddr.SOAckMeth;
            cachedCustAddr.UsePromoPrice = currentCustAddr.UsePromoPrice;
        }

        private void RestoreProperties()
        {
            if (!currentAddress.IsNew)
            {
                currentAddress.IsDirty = false;
                currentAddress.IsValidated = true;

                currentAddress.SalesTaxKey = cachedAddress.SalesTaxKey;
                currentAddress.Zip5 = cachedAddress.Zip5;
                currentAddress.Zip4 = cachedAddress.Zip4;
                currentAddress.Type = cachedAddress.Type;
                currentAddress.Data.Name = cachedAddress.Data.Name;
                currentAddress.Data.Line1 = cachedAddress.Data.Line1;
                currentAddress.Data.Line2 = cachedAddress.Data.Line2;
                currentAddress.Data.City = cachedAddress.Data.City;
                currentAddress.Data.State = cachedAddress.Data.State;
                currentAddress.Data.Zip = cachedAddress.Data.Zip;
                currentAddress.Data.Residential = cachedAddress.Data.Residential;

                var currentCustAddr = customer.CustAddresses.First(c => c.Key == currentAddress.Data.Key);

                currentCustAddr.WhseKey = cachedCustAddr.WhseKey;
                currentCustAddr.SalesTerritoryKey = cachedCustAddr.SalesTerritoryKey;
                currentCustAddr.STaxSchdKey = cachedCustAddr.STaxSchdKey;
                currentCustAddr.UpdateDate = cachedCustAddr.UpdateDate;
                currentCustAddr.UpdateUserID = cachedCustAddr.UpdateUserID;
                currentCustAddr.Type = cachedCustAddr.Type;

                currentCustAddr.PmtTermsKey = cachedCustAddr.PmtTermsKey;
                currentCustAddr.ShipMethKey = cachedCustAddr.ShipMethKey;
                currentCustAddr.InvcFormKey = cachedCustAddr.InvcFormKey;
                currentCustAddr.PackListFormKey = cachedCustAddr.PackListFormKey;

                currentCustAddr.AllowInvtSubst = cachedCustAddr.AllowInvtSubst;
                currentCustAddr.CurrID = cachedCustAddr.CurrID;
                currentCustAddr.FOBKey = cachedCustAddr.FOBKey;
                currentCustAddr.LanguageID = cachedCustAddr.LanguageID;
                currentCustAddr.RequireSOAck = cachedCustAddr.RequireSOAck;
                currentCustAddr.ShipComplete = cachedCustAddr.ShipComplete;
                currentCustAddr.ShipLabelFormKey = cachedCustAddr.ShipLabelFormKey;
                currentCustAddr.SOAckFormKey = cachedCustAddr.SOAckFormKey;
                currentCustAddr.SperKey = cachedCustAddr.SperKey;

                currentCustAddr.BackOrdPrice = cachedCustAddr.BackOrdPrice;
                currentCustAddr.BOLReqd = cachedCustAddr.BOLReqd;
                currentCustAddr.CarrierAcctNo = cachedCustAddr.CarrierAcctNo;
                currentCustAddr.CarrierBillMeth = cachedCustAddr.CarrierBillMeth;
                currentCustAddr.CloseSOLineOnFirstShip = cachedCustAddr.CloseSOLineOnFirstShip;
                currentCustAddr.CloseSOOnFirstShip = cachedCustAddr.CloseSOOnFirstShip;
                currentCustAddr.CreateDate = cachedCustAddr.CreateDate;
                currentCustAddr.CreateType = cachedCustAddr.CreateType;
                currentCustAddr.CreateUserID = cachedCustAddr.CreateUserID;
                currentCustAddr.FreightMethod = cachedCustAddr.FreightMethod;
                currentCustAddr.InvcMsg = cachedCustAddr.InvcMsg;
                currentCustAddr.InvoiceReqd = cachedCustAddr.InvoiceReqd;
                currentCustAddr.InvcFormKey = cachedCustAddr.InvcFormKey;
                currentCustAddr.PackListContentsReqd = cachedCustAddr.PackListContentsReqd;
                currentCustAddr.PackListReqd = cachedCustAddr.PackListReqd;
                currentCustAddr.PriceAdj = cachedCustAddr.PriceAdj;
                currentCustAddr.PriceBase = cachedCustAddr.PriceBase;
                currentCustAddr.PrintOrderAck = cachedCustAddr.PrintOrderAck;
                currentCustAddr.ShipDays = cachedCustAddr.ShipDays;
                currentCustAddr.ShipLabelsReqd = cachedCustAddr.ShipLabelsReqd;
                currentCustAddr.SOAckMeth = cachedCustAddr.SOAckMeth;
                currentCustAddr.UsePromoPrice = cachedCustAddr.UsePromoPrice;
            }
        }
        #endregion









        //--------------NEW-----------------
        private void btnNew_Click(object sender, EventArgs e)
        {
            bool proceed = NotifyIfAddressIsDirty();
            if (proceed)
            {
                currentAddress = new BLAddress();
                currentAddress.Data = new Address();
                currentCustAddress = new CustAddress();

                addressControl.ClearForm();
                txtTaxRate.Clear();
                statusLabel.Text = string.Empty;

                UnsubscribeFromCheckChanged();
                chkPrimaryBilling.Checked = false;
                chkShipping.Checked = false;
                chkCommon.Checked = true;
                rdoActive.Checked = true;
                rdoActive.Enabled = false;
                rdoDeleted.Enabled = false;
                SubscribeToCheckChanged();
            }
        }

        private bool NotifyIfAddressIsDirty()
        {
            if (currentAddress.IsDirty)
            {
                var result = MessageBox.Show("Address has been edited. Would you like to save your changes?", "Warning", MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        if (currentAddress.IsValidated)
                        {
                            btnSave.PerformClick();
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Address has not been validated. Unable to save.");
                            if (!currentAddress.IsNew)
                            {
                                var currentList = GetCurrentList();
                                addressDataGridView.SelectDGVRow(currentList.FindIndex(c => c.Data.Key == currentAddress.Data.Key));
                            }

                            return false;
                        }


                    case DialogResult.No:
                        if (!currentAddress.IsNew)
                            RestoreProperties();
                        statusLabel.Text = "";
                        return true;
                }
                return false;
            }
            else
                return true;
        }










        private int cachedAddrKeyForRowSelection;

        //SAVE ADDRESS
        private void btnSave_Click(object sender, EventArgs e)
        {
            AssignPrimaryBillingAndShippingToCustomer();
            AutoAssignDefaultShipToOnDeletion();


            if (currentAddress.IsNew)
            {
                currentCustAddress.Address = currentAddress.Data;

                cachedAddrKeyForRowSelection = service.InsertCustAddrAndAssignCustomerDefaultAddress(customer, currentCustAddress, chkPrimaryBilling.Checked, chkShipping.Checked);
            }
            else
            {
                var custAddrToUpdate = customer.CustAddresses.First(c => c.Key == currentAddress.Data.Key);
                custAddrToUpdate.Address = currentAddress.Data;

                cachedAddrKeyForRowSelection = currentAddress.Data.Key;
                service.UpdateCustomer(customer);
            }

            currentAddress.IsDirty = false;

            statusLabel.Text = "Saved!";
            statusLabel.ForeColor = Color.Green;


            LoadCustomerAndSetUpList();
            addressDataGridView.Refresh(GetCurrentList());
            SetCountLabel();
            SelectRowFromCurrentAddress();
            SetCurrentAddressFromSelectedRow();
            SetFormToCurrentAddress();

            btnSave.Enabled = false;

            AddTaxExemptionsToCustAddresses();
            service.UpdateCustomer(customer);
            AddressUpdatedOrAdded();
        }

        private void AutoAssignDefaultShipToOnDeletion()
        {
            if (currentAddress.IsDefaultShipping && currentCustAddress.ShipDays > 90)
            {
                customer.DefaultShipToAddress = customer.DefaultBillToAddress;
                customer.DfltShipToAddrKey = currentAddress.Data.Key;
            }
        }

        private void AssignPrimaryBillingAndShippingToCustomer()
        {
            if (chkPrimaryBilling.Checked)
            {
                customer.PrimaryAddress = currentAddress.Data;
                customer.PrimaryAddrKey = currentAddress.Data.Key;

                customer.DefaultBillToAddress = currentAddress.Data;
                customer.DfltBillToAddrKey = currentAddress.Data.Key;
            }

            if (chkShipping.Checked)
            {
                customer.DefaultShipToAddress = currentAddress.Data;
                customer.DfltShipToAddrKey = currentAddress.Data.Key;
            }
        }

        private void AddTaxExemptionsToCustAddresses()
        {
            //create lists to hold onto taxcodes from current addresses
            var caTaxCodes = new List<TaxCode>();
            var waTaxCodes = new List<TaxCode>();
            var moTaxCodes = new List<TaxCode>();

            //loop through all cust addresses
            foreach (var custAddr in customer.CustAddresses)
            {
                //get all tax codes bundled in a list
                if (custAddr.Address.State == "CA")
                    caTaxCodes.AddRange(custAddr.TaxSchedule.TaxCodes);

                if (custAddr.Address.State == "WA")
                    waTaxCodes.AddRange(custAddr.TaxSchedule.TaxCodes);

                if (custAddr.Address.State == "MO")
                    moTaxCodes.AddRange(custAddr.TaxSchedule.TaxCodes);
            }

            //store exemption info
            var currentCATaxExemption = customer.TaxExemptionsCPC.FirstOrDefault(c => c.State.Contains("CA"));
            var currentWATaxExemption = customer.TaxExemptionsCPC.FirstOrDefault(c => c.State.Contains("WA"));
            var currentMOTaxExemption = customer.TaxExemptionsCPC.FirstOrDefault(c => c.State.Contains("MO"));

            //clear current tax exemptions list
            customer.CustAddresses.ForEach(custAddr => custAddr.TaxExemptionsAcuity.Clear());

            //distinct only
            if (caTaxCodes.Count != 0)
                caTaxCodes = caTaxCodes.GroupBy(c => c.Key).Select(c => c.First()).ToList();

            if (waTaxCodes.Count != 0)
                waTaxCodes = waTaxCodes.GroupBy(c => c.Key).Select(c => c.First()).ToList();

            if (moTaxCodes.Count != 0)
                moTaxCodes = moTaxCodes.GroupBy(c => c.Key).Select(c => c.First()).ToList();

            //add tax codes and exemptions belonging to CA
            if (currentCATaxExemption != null)
            {
                foreach (var caTaxCode in caTaxCodes)
                {
                    foreach (var custAddr in customer.CustAddresses)
                    {
                        custAddr.TaxExemptionsAcuity.Add(new TaxExemptionAcuity
                        {
                            AddrKey = custAddr.Key,
                            STaxCodeKey = caTaxCode.Key,
                            ExmptNo = currentCATaxExemption.ExemptNo
                        });
                    }
                }
            }


            //add tax codes and exemption belonging to MO
            if (currentMOTaxExemption != null)
            {
                foreach (var moTaxCode in moTaxCodes)
                {
                    foreach (var custAddr in customer.CustAddresses)
                    {
                        custAddr.TaxExemptionsAcuity.Add(new TaxExemptionAcuity
                        {
                            AddrKey = custAddr.Key,
                            STaxCodeKey = moTaxCode.Key,
                            ExmptNo = currentMOTaxExemption.ExemptNo
                        });
                    }
                }
            }


            //add tax codes and exemption belonging to WA
            if (currentWATaxExemption != null)
            {
                foreach (var waTaxCode in waTaxCodes)
                {
                    foreach (var custAddr in customer.CustAddresses)
                    {
                        custAddr.TaxExemptionsAcuity.Add(new TaxExemptionAcuity
                        {
                            AddrKey = custAddr.Key,
                            STaxCodeKey = waTaxCode.Key,
                            ExmptNo = currentWATaxExemption.ExemptNo
                        });
                    }
                }
            }
        }


        private void SelectRowFromCurrentAddress()
        {
            var currentList = GetCurrentList();
            int index = currentList.FindIndex(c => c.Data.Key == cachedAddrKeyForRowSelection);
            if (index != -1)
            {
                addressDataGridView.SelectDGVRow(index);
            }
        }

        private List<BLAddress> GetCurrentList()
        {
            if (chkShowDeleted.Checked)
            {
                return deletedAddresses;
            }
            else
            { 
                return activeAddresses;
            }
        }







        //ADDRESS TYPE CHECKCHANGED
        private void UnsubscribeFromCheckChanged()
        {
            chkPrimaryBilling.CheckedChanged -= chkPrimaryBilling_CheckedChanged;
            chkShipping.CheckedChanged -= chkShipping_CheckedChanged;
            chkCommon.CheckedChanged -= chkCommon_CheckedChanged;

            rdoActive.CheckedChanged -= rdoActive_CheckedChanged;
            rdoDeleted.CheckedChanged -= rdoDeleted_CheckedChanged;
        }

        private void SubscribeToCheckChanged()
        {
            chkPrimaryBilling.CheckedChanged += chkPrimaryBilling_CheckedChanged;
            chkShipping.CheckedChanged += chkShipping_CheckedChanged;
            chkCommon.CheckedChanged += chkCommon_CheckedChanged;

            rdoActive.CheckedChanged += rdoActive_CheckedChanged;
            rdoDeleted.CheckedChanged += rdoDeleted_CheckedChanged;
        }

        private void chkPrimaryBilling_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPrimaryBilling.Checked)
            {
                if (chkCommon.Checked)
                {
                    chkCommon.CheckedChanged -= chkCommon_CheckedChanged;
                    chkCommon.Checked = false;
                    chkCommon.CheckedChanged += chkCommon_CheckedChanged;
                }

                if (currentAddress.IsValidated)
                {
                    btnSave.Enabled = true;
                    currentAddress.IsDirty = true;
                    statusLabel.Text = "This address has been assigned primary address. Needs to be saved.";
                }
                else
                    btnSave.Enabled = false;
            }
            else
            {
                if (currentAddress.Data.Key == customer.PrimaryAddrKey)
                {
                    MessageBox.Show("You cannot unassign primary address. You must assign a new primary address instead.");
                    UnsubscribeFromCheckChanged();
                    chkPrimaryBilling.Checked = true;
                    SubscribeToCheckChanged();
                }
                else
                {
                    statusLabel.Text = "";
                }

                if (!chkShipping.Checked && !chkPrimaryBilling.Checked)
                    chkCommon.Checked = true;
            }
        }


        private void chkShipping_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShipping.Checked)
            {
                if (chkCommon.Checked)
                {
                    chkCommon.CheckedChanged -= chkCommon_CheckedChanged;
                    chkCommon.Checked = false;
                    chkCommon.CheckedChanged += chkCommon_CheckedChanged;
                }

                if (currentAddress.IsValidated)
                {
                    btnSave.Enabled = true;
                    currentAddress.IsDirty = true;
                    statusLabel.Text = "This address has been assigned default ship to. Needs to be saved.";
                }
                else
                    btnSave.Enabled = false;
            }
            else
            {
                if (currentAddress.Data.Key == customer.DfltShipToAddrKey)
                {
                    MessageBox.Show("You cannot unassign default ship to address. You must assign a new ship to address instead.");
                    UnsubscribeFromCheckChanged();
                    chkShipping.Checked = true;
                    SubscribeToCheckChanged();
                }
                else
                {
                    statusLabel.Text = "";
                }

                if (!chkShipping.Checked && !chkPrimaryBilling.Checked)
                    chkCommon.Checked = true;
            }
        }

        private void chkCommon_CheckedChanged(object sender, EventArgs e)
        {
            if((chkCommon.Checked) && (chkPrimaryBilling.Checked || chkShipping.Checked) && (currentAddress.IsNew))
            {
                chkPrimaryBilling.CheckedChanged -= chkPrimaryBilling_CheckedChanged;
                chkShipping.CheckedChanged -= chkShipping_CheckedChanged;
                chkPrimaryBilling.Checked = false;
                chkShipping.Checked = false;
                chkPrimaryBilling.CheckedChanged += chkPrimaryBilling_CheckedChanged;
                chkShipping.CheckedChanged += chkShipping_CheckedChanged;

                statusLabel.Text = "This address has been assigned to common shipping. Needs to be saved.";

                if (currentAddress.IsValidated)
                {
                    btnSave.Enabled = true;
                    currentAddress.IsDirty = true;
                    statusLabel.Text = "This address has been assigned to common shipping. Needs to be saved.";
                }
                else
                    btnSave.Enabled = false;
            }
            else if (chkCommon.Checked && currentAddress.IsNew)
            {
                if (currentAddress.IsValidated)
                {
                    btnSave.Enabled = true;
                    currentAddress.IsDirty = true;
                    statusLabel.Text = "This address has been assigned to common shipping. Needs to be saved.";
                }
                else
                    btnSave.Enabled = false;
            }
            else if ((chkCommon.Checked) && (chkPrimaryBilling.Checked || chkShipping.Checked) && (!currentAddress.IsNew))
            {   
                statusLabel.Text = "Cannot convert this into CSA. Must assign a primary billing / default shipping to another address.";
                statusLabel.ForeColor = Color.Red;

                chkCommon.CheckedChanged -= chkCommon_CheckedChanged;
                chkCommon.Checked = false;
                chkCommon.CheckedChanged += chkCommon_CheckedChanged;

            }
            else if (!chkCommon.Checked && !currentAddress.IsNew)
            {
                statusLabel.Text = "Cannot unassign CSA to this address. Must choose primary billing and/or default shipping.";
                statusLabel.ForeColor = Color.Red;

                chkCommon.CheckedChanged -= chkCommon_CheckedChanged;
                chkCommon.Checked = true;
                chkCommon.CheckedChanged += chkCommon_CheckedChanged;
            }
        }







        //TOGGLE ACTIVE AND INACTIVE ADDRESSES
        private void chkDeleted_CheckedChanged(object sender, EventArgs e)
        {
            var currentList = GetCurrentList();
            addressDataGridView.Refresh(currentList);
            SetCountLabel();
            SelectRowFromCurrentAddress();
            SetCurrentAddressFromSelectedRow();
            SetFormToCurrentAddress();

            btnSave.Enabled = false;
            statusLabel.Text = "";
        }

        private void SetCurrentAddressFromSelectedRow()
        {
            var currentList = GetCurrentList();
            currentAddress = currentList.FirstOrDefault(c => c.Data.Key == cachedAddrKeyForRowSelection);

            if (currentAddress == null)
            {
                if (currentList.Count == 0)
                {
                    currentAddress = new BLAddress();
                    currentAddress.Data = new Address();
                    currentCustAddress = new CustAddress();
                }
                else
                {
                    currentAddress = currentList[0];
                    currentAddress.Data = currentList[0].Data;
                    currentCustAddress = customer.CustAddresses.First(c => c.Key == currentAddress.Data.Key);

                    CacheCurrentAddress();
                    CacheCustAddress();
                }

            }
            else
            {
                currentAddress.Data = currentList.First(c => c.Data.Key == cachedAddrKeyForRowSelection).Data;
                currentCustAddress = customer.CustAddresses.First(c => c.Key == currentAddress.Data.Key);

                CacheCurrentAddress();
                CacheCustAddress();
            }
        }






        //FORM CLOSE
        private void btnClose_Click(object sender, EventArgs e)
        {
            bool proceed = NotifyIfAddressIsDirty();
            if (proceed)
            {
                Close();
            }
        }



        //ACTIVATE AND DEACTIVATE
        private void rdoActive_CheckedChanged(object sender, EventArgs e)
        {
            currentAddress.IsDirty = true;
            if (rdoActive.Checked)
            {
                currentCustAddress.ShipDays = 3;
                if (addressControl.IsValid)
                    btnSave.Enabled = true;
            }
        }

        private void rdoDeleted_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDeleted.Checked)
            {
                currentCustAddress.ShipDays = 101;
                if (addressControl.IsValid)
                    btnSave.Enabled = true;
            }
        }

        private void rdoDeleted_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.PerformClick();
            }
        }

        private void rdoActive_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.PerformClick();
            }
        }

    }
}
