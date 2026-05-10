namespace site.Types
{
	public class Post
	{

		public Post(Guid id, string coverImageUrl, string title, User author)
		{
			Id = id;
			CoverImageUrl = coverImageUrl;
			Title = title;
			Author = author;
		}

		public Guid Id { get; }

		public string CoverImageUrl { get; }

		public string Title { get; }

		public User Author { get; }

		public DateTimeOffset CreationDate { get; }

	}
}

