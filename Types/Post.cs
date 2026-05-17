namespace site.Types
{
	public sealed class Post(int id, string coverImageUrl, string title, User author)
	{
		public int Id { get; } = id;

		public string CoverImageUrl { get; } = coverImageUrl;

		public string Title { get; } = title;

		public User Author { get; } = author;

		public DateTimeOffset CreationDate { get; } = DateTimeOffset.UtcNow;
	}
}

