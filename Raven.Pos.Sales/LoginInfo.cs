namespace Raven.Pos.Sales
{
    public class LoginInfo
    {
        private string _userID;
        private string _userName;
        private string _userGroupID;
        private string _branchID;
        private string _branchName;
        private string _CompanyID;
        private string _CompanyName;

        public LoginInfo(string userID, string userName, string userGroupID, string branchID, string branchName, string CompanyID, string CompanyName)
        {
            _userID = userID;
            _userName = userName;
            _userGroupID = userGroupID;
            _branchID = branchID;
            _branchName = branchName;
            _CompanyID = CompanyID;
            _CompanyName = CompanyName;
        }

        public string UserID
        {
            get { return _userID; }
        }
        public string UserName
        {
            get { return _userName; }
        }
        public string UserGroupID
        {
            get { return _userGroupID; }
        }
        public string BranchID
        {
            get { return _branchID; }
        }
        public string BranchName
        {
            get { return _branchName; }
        }
        public string CompanyID
        {
            get { return _CompanyID; }
        }
        public string CompanyName
        {
            get { return _CompanyName; }
        }    
    }
}
