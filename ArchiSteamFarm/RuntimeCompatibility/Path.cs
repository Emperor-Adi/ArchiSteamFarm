﻿//     _                _      _  ____   _                           _____
//    / \    _ __  ___ | |__  (_)/ ___| | |_  ___   __ _  _ __ ___  |  ___|__ _  _ __  _ __ ___
//   / _ \  | '__|/ __|| '_ \ | |\___ \ | __|/ _ \ / _` || '_ ` _ \ | |_  / _` || '__|| '_ ` _ \
//  / ___ \ | |  | (__ | | | || | ___) || |_|  __/| (_| || | | | | ||  _|| (_| || |   | | | | | |
// /_/   \_\|_|   \___||_| |_||_||____/  \__|\___| \__,_||_| |_| |_||_|   \__,_||_|   |_| |_| |_|
// |
// Copyright 2015-2021 Łukasz "JustArchi" Domeradzki
// Contact: JustArchi@JustArchi.net
// |
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// |
// http://www.apache.org/licenses/LICENSE-2.0
// |
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#if NETFRAMEWORK
using System;
#endif
using JetBrains.Annotations;

namespace ArchiSteamFarm.RuntimeCompatibility {
	[PublicAPI]
	public static class Path {
		public static string GetRelativePath(string relativeTo, string path) {
#if NETFRAMEWORK
			if (relativeTo == null) {
				throw new ArgumentNullException(nameof(relativeTo));
			}

			if (path == null) {
				throw new ArgumentNullException(nameof(path));
			}

			if (!path.StartsWith(relativeTo, StringComparison.Ordinal)) {
				throw new NotImplementedException();
			}

			string result = path[relativeTo.Length..];

			return (result[0] == System.IO.Path.DirectorySeparatorChar) || (result[0] == System.IO.Path.AltDirectorySeparatorChar) ? result[1..] : result;
#else
			return System.IO.Path.GetRelativePath(relativeTo, path);
#endif
		}
	}
}