using System.Diagnostics;
using System.Reflection;

namespace CLAP
{
    /// <summary>
    /// A helper for method invoking to allow mocking for tests
    /// </summary>
    public static class MethodInvoker
    {
        public static IMethodInvoker Invoker { get; set; }

        static MethodInvoker()
        {
            Invoker = new DefaultMethodInvoker();
        }

        public static object Invoke(MethodInfo method, object obj, object[] parameters)
        {
            Debug.Assert(method != null);

            return Invoker.Invoke(method, obj, parameters);
        }

        private class DefaultMethodInvoker : IMethodInvoker
        {
            public object Invoke(MethodInfo method, object obj, object[] parameters)
            {
                return method.Invoke(obj, parameters);
            }
        }
    }

    public interface IMethodInvoker
    {
        object Invoke(MethodInfo method, object obj, object[] parameters);
    }
}