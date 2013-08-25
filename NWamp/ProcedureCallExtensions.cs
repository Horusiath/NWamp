using NWamp.Rpc;
using System;

namespace NWamp
{
    /// <summary>
    /// Extension method container used for easing registration of methods for new remote procedure calls.
    /// </summary>
    public static class ProcedureCallExtensions
    {
        public static BaseWampHost RegisterAction(this BaseWampHost listener, string procUri, Action action)
        {
            return listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, action));
        }

        public static BaseWampHost RegisterAction<T1>(this BaseWampHost listener, string procUri, Action<T1> action)
        {
            return listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, action));
        }

        public static BaseWampHost RegisterAction<T1, T2>(this BaseWampHost listener, string procUri, Action<T1, T2> action)
        {
            return listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, action));
        }

        public static BaseWampHost RegisterAction<T1, T2, T3>(this BaseWampHost listener, string procUri, Action<T1, T2, T3> action)
        {
            return listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, action));
        }

        public static BaseWampHost RegisterAction<T1, T2, T3, T4>(this BaseWampHost listener, string procUri, Action<T1, T2, T3, T4> action)
        {
            return listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, action));
        }

        public static BaseWampHost RegisterAction<T1, T2, T3, T4, T5>(this BaseWampHost listener, string procUri, Action<T1, T2, T3, T4, T5> action)
        {
            return listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, action));
        }

        public static BaseWampHost RegisterAction<T1, T2, T3, T4, T5, T6>(this BaseWampHost listener, string procUri, Action<T1, T2, T3, T4, T5, T6> action)
        {
            return listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, action));
        }

        public static BaseWampHost RegisterAction<T1, T2, T3, T4, T5, T6, T7>(this BaseWampHost listener, string procUri, Action<T1, T2, T3, T4, T5, T6, T7> action)
        {
            return listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, action));
        }

        public static BaseWampHost RegisterAction<T1, T2, T3, T4, T5, T6, T7, T8>(this BaseWampHost listener, string procUri, Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
        {
            return listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, action));
        }

        public static BaseWampHost RegisterFunction<TResult>(this BaseWampHost listener, string procUri, Func<TResult> function)
        {
            return listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, function));
        }

        public static BaseWampHost RegisterFunction<T1, TResult>(this BaseWampHost listener, string procUri, Func<T1, TResult> function)
        {
            return listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, function));
        }

        public static BaseWampHost RegisterFunction<T1, T2, TResult>(this BaseWampHost listener, string procUri, Func<T1, T2, TResult> function)
        {
            return listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, function));
        }

        public static BaseWampHost RegisterFunction<T1, T2, T3, TResult>(this BaseWampHost listener, string procUri, Func<T1, T2, T3, TResult> function)
        {
            return listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, function));
        }

        public static BaseWampHost RegisterFunction<T1, T2, T3, T4, TResult>(this BaseWampHost listener, string procUri, Func<T1, T2, T3, T4, TResult> function)
        {
            return listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, function));
        }

        public static BaseWampHost RegisterFunction<T1, T2, T3, T4, T5, TResult>(this BaseWampHost listener, string procUri, Func<T1, T2, T3, T4, T5, TResult> function)
        {
            return listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, function));
        }

        public static BaseWampHost RegisterFunction<T1, T2, T3, T4, T5, T6, TResult>(this BaseWampHost listener, string procUri, Func<T1, T2, T3, T4, T5, T6, TResult> function)
        {
            return listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, function));
        }

        public static BaseWampHost RegisterFunction<T1, T2, T3, T4, T5, T6, T7, TResult>(this BaseWampHost listener, string procUri, Func<T1, T2, T3, T4, T5, T6, T7, TResult> function)
        {
            return listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, function));
        }

        public static BaseWampHost RegisterFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this BaseWampHost listener, string procUri, Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> function)
        {
            return listener.RegisterProcedure(ProcedureDefinitions.Create(procUri, function));
        }
    }
}
