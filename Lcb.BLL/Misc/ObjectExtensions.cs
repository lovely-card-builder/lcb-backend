namespace Lcb.BLL.Misc
{
    public static class ObjectExtensions
    {
        public static void EnsureNotNullFatal<T>(this T obj, string message = "")
        {
            if (obj == null)
            {
                throw new(message);
            }
        }

        public static void EnsureNotNullHandled<T>(this T obj, string message = "")
        {
            if (obj == null)
            {
                throw new BusinessException(message);
            }
        }
    }
}