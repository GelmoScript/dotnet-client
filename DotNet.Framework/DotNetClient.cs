// --------------------------------------------------
// <copyright file="DotNetClient.cs" company="GMS">
// Copyright (c) GMS. All rights reserved.
// </copyright>
// --------------------------------------------------

using DotNet.Framework.Contracts;

namespace DotNet.Framework
{
    /// <summary>
    /// Represents a standart for executing dotnet cli commands.
    /// </summary>
    public static class DotNetClient
    {
        /// <summary>
        /// Creates a new .NET project or file.
        /// </summary>
        /// <param name="name">The name of the template to be created.</param>
        /// <typeparam name="TTemplate">The template type of the project.</typeparam>
        /// <returns>The template created.</returns>
        /// <exception cref="InvalidOperationException">Throws an error when template could not be created.</exception>
        public static TTemplate New<TTemplate>(string name)
            where TTemplate : ITemplate
        {
            Type templateType = typeof(TTemplate);
            TTemplate? template = (TTemplate?)Activator.CreateInstance(templateType, new object[] { name });

            if (template is null)
                throw new InvalidOperationException($"Cannot create an instance of type {templateType}");

            return template;
        }

        /// <summary>
        /// Creates a new .NET project or file.
        /// </summary>
        /// <param name="args">The arguments for create the template.</param>
        /// <typeparam name="TTemplate">The template type of the project.</typeparam>
        /// <returns>The template created.</returns>
        /// <exception cref="InvalidOperationException">Throws an error when template could not be created.</exception>
        public static TTemplate New<TTemplate>(params object[] args)
            where TTemplate : ITemplate
        {
            Type templateType = typeof(TTemplate);
            TTemplate? template = (TTemplate?)Activator.CreateInstance(templateType, args);

            if (template is null)
                throw new InvalidOperationException($"Cannot create an instance of type {templateType}");

            return template;
        }
    }
}