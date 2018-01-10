namespace Amlak.Core.SSOT
{
    public class AppSetting
    {
        public bool ClearConsoleLog { get; set; } = true;
        public int BidIncreasement { get; set; } = 100;
        public bool PreventDuplicateBids { get; set; } = true;
        public int PropBidsTillQuestion { get; set; } = 250;
        public int InitialUserRegistrationCoins { get; set; } = 0;
        public int CoinPrice { get; set; } = 5000;

        public string FacebookLink { get; set; }
        public string TelegramLink { get; set; }
        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }

        public bool HideGoogleTagManager { get; set; }
    }
}