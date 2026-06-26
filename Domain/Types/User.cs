using Domain.Constants;

namespace Domain.Types
{
	public class User
	{

		public User(string id, string fullName, string displayName, string profilePicture = UrlConstants.DefaultProfilePicture)
		{
			Id = id;
			FullName = fullName;
			DisplayName = displayName;
			ProfilePicture = profilePicture;
			CreationDate = DateTimeOffset.UtcNow;
		}

		public string Id { get; }

		public string FullName { get; }

		public string DisplayName { get; }

		public string ProfilePicture { get; }

		public DateTimeOffset CreationDate { get; }

	}
}

