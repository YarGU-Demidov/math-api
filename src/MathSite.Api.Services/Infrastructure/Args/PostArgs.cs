namespace MathSite.Api.Services.Infrastructure.Args
{
    public enum PublishStatus
    {
        Any,
        Published,
        Unpubished
    }

    public enum FrontPageStatus
    {
        Any,
        Visible,
        Invisible
    }

    public enum ItemAvailableStatus
    {
        Any,
        Alive,
        Removed
    }

    public abstract class PostArgs
    {
        public PostArgs() { }
        protected PostArgs(
            PublishStatus publishStatus = PublishStatus.Any,
            FrontPageStatus frontPageStatus = FrontPageStatus.Any,
            ItemAvailableStatus itemAvailableStatus = ItemAvailableStatus.Any
        )
        {
            PublishStatus = publishStatus;
            FrontPageStatus = frontPageStatus;
            ItemAvailableStatus = itemAvailableStatus;
        }

        public PublishStatus PublishStatus { get; set; }
        public FrontPageStatus FrontPageStatus { get; set; }
        public ItemAvailableStatus ItemAvailableStatus { get; set; }
    }
}