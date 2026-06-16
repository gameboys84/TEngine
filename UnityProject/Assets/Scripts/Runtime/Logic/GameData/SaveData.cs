namespace GameLogic
{
    public class LocalPlayerInfo : LocalSaveDataBase
    {
        public string uuid;
        public string overrideUuid;
        public long playerId;
        public string LinkedEmailAddress; // 仅用于显示
        public string LoginEmailAddress;
        public string LastTryEmailAddress;
        public string RefreshToken;
    }
    // private LocalPlayerInfo localPlayerInfo = new LocalPlayerInfo()
    // {
    //     uuid = "123456",
    //     overrideUuid = "123123",
    //     playerId = 567890,
    //     LinkedEmailAddress = "game@email.com",
    //     LoginEmailAddress = "gameboys@email.com",
    //     LastTryEmailAddress = "",
    //     RefreshToken = "U2FsdGVkX18qJY4EdGj+HkGP24CePEPhw8Sx6VIERHU="
    // };
}