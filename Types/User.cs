using site.Constants;

namespace site.Types
{
	public class User
	{

		public User(Guid id, string firstName, string lastName, string profilePicture = UrlConstants.DefaultProfilePicture)
		{
			Id = id;
			FirstName = firstName;
			LastName = lastName;
			ProfilePicture = profilePicture;
			CreationDate = DateTimeOffset.UtcNow;
		}

		public Guid Id { get; }

		public string FirstName { get; }

		public string LastName { get; }

		public string FullName => FirstName + " " + LastName;

		public string ProfilePicture { get; }

		public DateTimeOffset CreationDate { get; }

	}
}

