using System;
using System.Threading.Tasks;

#pragma warning disable 1591
// ReSharper disable once CheckNamespace
namespace JetBrains.Annotations {
    /// <summary>Marked element could be <c>null</c></summary>
    [AttributeUsage(AttributeTargets.All)] public sealed class CanBeNullAttribute : Attribute { }
    /// <summary>Marked element could never be <c>null</c></summary>
    [AttributeUsage(AttributeTargets.All)] public sealed class NotNullAttribute : Attribute { }
    /// <summary>IEnumerable, Task.Result, or Lazy.Value property can never be null.</summary>
    [AttributeUsage(AttributeTargets.All)] public sealed class ItemNotNullAttribute : Attribute { }
    /// <summary>IEnumerable, Task.Result, or Lazy.Value property can be null.</summary>
    [AttributeUsage(AttributeTargets.All)] public sealed class ItemCanBeNullAttribute : Attribute { }

    
    public static class MRA_TaskExtensions {
        /// <summary>
        /// Mark as task as never null. This solves some ReSharper annotation issues around
        /// async/await.
        /// </summary>
        [NotNull] public static Task<T> NotNull<T>([CanBeNull] this Task<T> task) => task ?? throw new Exception("Task creation failed");
    }
}