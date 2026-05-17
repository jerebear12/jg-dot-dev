using System.Collections.Immutable;

namespace site.Types
{
	public sealed class Post(int id, string slug, string coverImageUrl, string title, User author, DateTimeOffset? creationDate = null)
	{

		#region Properties

		public int Id { get; } = id;

		public string Slug { get; } = slug;

		public string CoverImageUrl { get; } = coverImageUrl;

		public string Title { get; } = title;

		public User Author { get; } = author;

		public DateTimeOffset CreationDate { get; } = creationDate ?? DateTimeOffset.UtcNow;

		#endregion
		
	}
}

