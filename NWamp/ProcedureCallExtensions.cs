using NWamp.Rpc;
using System;

namespace NWamp
{
    /// <summary>
    /// Extension method container used for easing registration of methods for new remote procedure calls.
    /// </summary>
    public static class ProcedureCallExtensions
    {
        public static void RegisterAction(this BaseWampHost listener, string procUri, Action action)
        {
            listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, action));
        }

        public static void RegisterAction<T1>(this BaseWampHost listener, string procUri, Action<T1> action)
        {
            listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, action));
        }

        public static void RegisterAction<T1, T2>(this BaseWampHost listener, string procUri, Action<T1, T2> action)
        {
            listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, action));
        }

        public static void RegisterAction<T1, T2, T3>(this BaseWampHost listener, string procUri, Action<T1, T2, T3> action)
        {
            listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, action));
        }

        public static void RegisterAction<T1, T2, T3, T4>(this BaseWampHost listener, string procUri, Action<T1, T2, T3, T4> action)
        {
            listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, action));
        }

        public static void RegisterAction<T1, T2, T3, T4, T5>(this BaseWampHost listener, string procUri, Action<T1, T2, T3, T4, T5> action)
        {
            listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, action));
        }

        public static void RegisterAction<T1, T2, T3, T4, T5, T6>(this BaseWampHost listener, string procUri, Action<T1, T2, T3, T4, T5, T6> action)
        {
            listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, action));
        }

        public static void RegisterAction<T1, T2, T3, T4, T5, T6, T7>(this BaseWampHost listener, string procUri, Action<T1, T2, T3, T4, T5, T6, T7> action)
        {
            listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, action));
        }

        public static void RegisterAction<T1, T2, T3, T4, T5, T6, T7, T8>(this BaseWampHost listener, string procUri, Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
        {
            listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, action));
        }

        public static void RegisterFunction<TResult>(this BaseWampHost listener, string procUri, Func<TResult> function)
        {
            listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, function));
        }

        public static void RegisterFunction<T1, TResult>(this BaseWampHost listener, string procUri, Func<T1, TResult> function)
        {
            listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, function));
        }

        public static void RegisterFunction<T1, T2, TResult>(this BaseWampHost listener, string procUri, Func<T1, T2, TResult> function)
        {
            listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, function));
        }

        public static void RegisterFunction<T1, T2, T3, TResult>(this BaseWampHost listener, string procUri, Func<T1, T2, T3, TResult> function)
        {
            listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, function));
        }

        public static void RegisterFunction<T1, T2, T3, T4, TResult>(this BaseWampHost listener, string procUri, Func<T1, T2, T3, T4, TResult> function)
        {
            listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, function));
        }

        public static void RegisterFunction<T1, T2, T3, T4, T5, TResult>(this BaseWampHost listener, string procUri, Func<T1, T2, T3, T4, T5, TResult> function)
        {
            listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, function));
        }

        public static void RegisterFunction<T1, T2, T3, T4, T5, T6, TResult>(this BaseWampHost listener, string procUri, Func<T1, T2, T3, T4, T5, T6, TResult> function)
        {
            listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, function));
        }

        public static void RegisterFunction<T1, T2, T3, T4, T5, T6, T7, TResult>(this BaseWampHost listener, string procUri, Func<T1, T2, T3, T4, T5, T6, T7, TResult> function)
        {
            listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, function));
        }

        public static void RegisterFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this BaseWampHost listener, string procUri, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> function)
        {
            listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, function));
        }
    }
}
