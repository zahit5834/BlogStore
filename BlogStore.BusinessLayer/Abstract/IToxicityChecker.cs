namespace BlogStore.BusinessLayer.Abstract
{

    public interface IToxicityChecker
    {
        Task<bool> IsToxicAsync(string text);
    }
}
