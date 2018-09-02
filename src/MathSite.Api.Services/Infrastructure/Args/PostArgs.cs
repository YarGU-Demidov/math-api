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

        public PublishStatus PublishStatus { get; }
        public FrontPageStatus FrontPageStatus { get; }
        public ItemAvailableStatus ItemAvailableStatus { get; }
    }
}