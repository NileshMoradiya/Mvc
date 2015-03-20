﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.IO;
using Microsoft.Framework.Internal;

namespace Microsoft.AspNet.Mvc.Razor.Internal
{
    public class DesignTimeRazorPathNormalizer : RazorPathNormalizer
    {
        private readonly string _applicationRoot;

        public DesignTimeRazorPathNormalizer([NotNull] string applicationRoot)
        {
            _applicationRoot = applicationRoot;
        }

        public override string NormalizePath(string path)
        {
            // Need to convert sourceFileName to application relative (rooted paths are passed in during design time).
            if (Path.IsPathRooted(path))
            {
                path = path.Substring(_applicationRoot.Length);
            }

            return path;
        }
    }
}