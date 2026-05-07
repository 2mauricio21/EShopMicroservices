namespace Ordering.Domain.Models
{
    public class Custumer : Entity<CustumerId>
    {
        public string Name { get; private set; } = default!;
        public string Email { get; private set; } = default!;

        public static Custumer Create(CustumerId id, string name, string email)
        {
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentException.ThrowIfNullOrEmpty(email);

            var custumer = new Custumer
            {
                Id = id,
                Name = name,
                Email = email
            };

            return custumer;
        }
    }
}
