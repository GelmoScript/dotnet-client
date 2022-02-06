// --------------------------------------------------
// <copyright file="ITemplate.cs" company="GMS">
// Copyright (c) GMS. All rights reserved.
// </copyright>
// --------------------------------------------------

namespace DotNet.Framework.Contracts
{
    /// <summary>
    /// Defines a set of methods that project templates use to be built.
    /// </summary>
    public interface ITemplate
    {
        /// <summary>
        /// Gets a template name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Builds the current template defined.
        /// </summary>
        void Build();
    }
}
