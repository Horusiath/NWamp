using System;

namespace NWamp.Rpc
{
    /// <summary>
    /// Static class used for easing creation of the typed <see cref="ProcedureDefinition"/> class instances.
    /// </summary>
    public static class ProcedureDefinitions
    {
        public static ProcedureDefinition Create(string procUri, Action action)
        {
            Func<object[], object> procCall =
                args =>
                {
                    action();
                    return null;
                };
            return new ProcedureDefinition(procUri, procCall);
        }

        public static ProcedureDefinition Create<T1>(string procUri, Action<T1> action)
        {
            Func<object[], object> procCall =
                args =>
                {
                    GuardArgumentsCount(args, 1);
                    action((T1)args[0]);
                    return null;
                };
            return new ProcedureDefinition(procUri, procCall)
            {
                ArgumentTypes = new[] { typeof(T1) }
            };
        }

        public static ProcedureDefinition Create<T1, T2>(string procUri, Action<T1, T2> action)
        {
            Func<object[], object> procCall =
                args =>
                {
                    GuardArgumentsCount(args, 2);
                    action((T1)args[0], (T2)args[1]);
                    return null;
                };
            return new ProcedureDefinition(procUri, procCall)
            {
                ArgumentTypes = new[] { typeof(T1), typeof(T2) }
            };
        }

        public static ProcedureDefinition Create<T1, T2, T3>(string procUri, Action<T1, T2, T3> action)
        {
            Func<object[], object> procCall =
                args =>
                {
                    GuardArgumentsCount(args, 3);
                    action((T1)args[0], (T2)args[1], (T3)args[2]);
                    return null;
                };
            return new ProcedureDefinition(procUri, procCall)
            {
                ArgumentTypes = new[] { typeof(T1), typeof(T2), typeof(T3) }
            };
        }

        public static ProcedureDefinition Create<T1, T2, T3, T4>(string procUri, Action<T1, T2, T3, T4> action)
        {
            Func<object[], object> procCall =
                args =>
                {
                    GuardArgumentsCount(args, 4);
                    action((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3]);
                    return null;
                };
            return new ProcedureDefinition(procUri, procCall)
            {
                ArgumentTypes = new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) }
            };
        }

        public static ProcedureDefinition Create<T1, T2, T3, T4, T5>(string procUri, Action<T1, T2, T3, T4, T5> action)
        {
            Func<object[], object> procCall =
                args =>
                {
                    GuardArgumentsCount(args, 5);
                    action((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4]);
                    return null;
                };
            return new ProcedureDefinition(procUri, procCall)
            {
                ArgumentTypes = new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) }
            };
        }

        public static ProcedureDefinition Create<T1, T2, T3, T4, T5, T6>(string procUri, Action<T1, T2, T3, T4, T5, T6> action)
        {
            Func<object[], object> procCall =
                args =>
                {
                    GuardArgumentsCount(args, 6);
                    action((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5]);
                    return null;
                };
            return new ProcedureDefinition(procUri, procCall)
            {
                ArgumentTypes = new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) }
            };
        }

        public static ProcedureDefinition Create<T1, T2, T3, T4, T5, T6, T7>(string procUri, Action<T1, T2, T3, T4, T5, T6, T7> action)
        {
            Func<object[], object> procCall =
                args =>
                {
                    GuardArgumentsCount(args, 7);
                    action((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6]);
                    return null;
                };
            return new ProcedureDefinition(procUri, procCall)
            {
                ArgumentTypes = new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) }
            };
        }

        public static ProcedureDefinition Create<T1, T2, T3, T4, T5, T6, T7, T8>(string procUri, Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
        {
            Func<object[], object> procCall =
                args =>
                {
                    GuardArgumentsCount(args, 8);
                    action((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7]);
                    return null;
                };
            return new ProcedureDefinition(procUri, procCall)
            {
                ArgumentTypes = new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) }
            };
        }

        public static ProcedureDefinition Create<TResult>(string procUri, Func<TResult> func)
        {
            Func<object[], object> procCall = args => func();
            return new ProcedureDefinition(procUri, procCall)
            {
                ResponseType = typeof(TResult)
            };
        }

        public static ProcedureDefinition Create<T1, TResult>(string procUri, Func<T1, TResult> func)
        {
            Func<object[], object> procCall =
                args =>
                {
                    GuardArgumentsCount(args, 1);
                    return func((T1)args[0]);
                };
            return new ProcedureDefinition(procUri, procCall)
            {
                ResponseType = typeof(TResult),
                ArgumentTypes = new[] { typeof(T1)}
            };
        }

        public static ProcedureDefinition Create<T1, T2, TResult>(string procUri, Func<T1, T2, TResult> func)
        {
            Func<object[], object> procCall =
                args =>
                {
                    GuardArgumentsCount(args, 2);
                    return func((T1)args[0], (T2)args[1]);
                };
            return new ProcedureDefinition(procUri, procCall)
            {
                ResponseType = typeof(TResult),
                ArgumentTypes = new[] { typeof(T1), typeof(T2) }
            };
        }

        public static ProcedureDefinition Create<T1, T2, T3, TResult>(string procUri, Func<T1, T2, T3, TResult> func)
        {
            Func<object[], object> procCall =
                args =>
                {
                    GuardArgumentsCount(args, 3);
                    return func((T1)args[0], (T2)args[1], (T3)args[2]);
                };
            return new ProcedureDefinition(procUri, procCall)
            {
                ResponseType = typeof(TResult),
                ArgumentTypes = new[] { typeof(T1), typeof(T2), typeof(T3) }
            };
        }

        public static ProcedureDefinition Create<T1, T2, T3, T4, TResult>(string procUri, Func<T1, T2, T3, T4, TResult> func)
        {
            Func<object[], object> procCall =
                args =>
                {
                    GuardArgumentsCount(args, 4);
                    return func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3]);
                };
            return new ProcedureDefinition(procUri, procCall)
            {
                ResponseType = typeof(TResult),
                ArgumentTypes = new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) }
            };
        }

        public static ProcedureDefinition Create<T1, T2, T3, T4, T5, TResult>(string procUri, Func<T1, T2, T3, T4, T5, TResult> func)
        {
            Func<object[], object> procCall =
                args =>
                {
                    GuardArgumentsCount(args, 5);
                    return func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4]);
                };
            return new ProcedureDefinition(procUri, procCall)
            {
                ResponseType = typeof(TResult),
                ArgumentTypes = new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) }
            };
        }

        public static ProcedureDefinition Create<T1, T2, T3, T4, T5, T6, TResult>(string procUri, Func<T1, T2, T3, T4, T5, T6, TResult> func)
        {
            Func<object[], object> procCall =
                args =>
                {
                    GuardArgumentsCount(args, 6);
                    return func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5]);
                };
            return new ProcedureDefinition(procUri, procCall);
        }

        public static ProcedureDefinition Create<T1, T2, T3, T4, T5, T6, T7, TResult>(string procUri, Func<T1, T2, T3, T4, T5, T6, T7, TResult> func)
        {
            Func<object[], object> procCall =
                args =>
                {
                    GuardArgumentsCount(args, 7);
                    return func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6]);
                };
            return new ProcedureDefinition(procUri, procCall)
            {
                ResponseType = typeof(TResult),
                ArgumentTypes = new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) }
            };
        }

        public static ProcedureDefinition Create<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(string procUri, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func)
        {
            Func<object[], object> procCall =
                args =>
                {
                    GuardArgumentsCount(args, 8);
                    return func((T1)args[0], (T2)args[1], (T3)args[2], (T4)args[3], (T5)args[4], (T6)args[5], (T7)args[6], (T8)args[7]);
                };
            return new ProcedureDefinition(procUri, procCall)
            {
                ResponseType = typeof(TResult),
                ArgumentTypes = new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) }
            };
        }

        private static void GuardArgumentsCount(object[] args, int expectedCount)
        {
            if (args.Length < expectedCount)
                throw new ArgumentException("Incompatibile number of arguments send from client. Expected number of arguments: " + expectedCount);

        }
    }
}
