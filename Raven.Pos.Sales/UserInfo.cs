namespace Raven.Pos.Sales
{
    public class UserInfo
    {
        private string _userID;
        private string _userName;
        private string _moduleID;
        private bool _isAllowUpdateOther;


        public UserInfo(string userID, string userName,string moduleID, bool isAllowUpdateOther)
        {
            _userID = userID;
            _userName = userName;
            _moduleID = moduleID;
            _isAllowUpdateOther = isAllowUpdateOther;
        }

        public string UserID
        {
            get { return _userID; }
        }

        public string UserName
        {
            get { return _userName; }
        }
        public string ModuleID
        {
            get { return _moduleID; }
        }
        public bool IsAllowUpdateOther
        {
            get { return _isAllowUpdateOther; }
        }
    }
}
