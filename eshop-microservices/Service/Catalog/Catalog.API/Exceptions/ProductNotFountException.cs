namespace Catalog.API.Exceptions
{
    public class ProductNotFountException : Exception
    {
        public ProductNotFountException() : base("Product not found.")
        {
        }
    }
}
