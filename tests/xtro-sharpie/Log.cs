﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Extrospection {

	static class Log {
		static Dictionary<string, List<string>> lists = new Dictionary<string, List<string>> ();

		public static IList<string> On (string fx)
		{
			List<string> list;

			string existingName = lists.Keys.FirstOrDefault (x => String.Compare (x, fx, true) == 0);
			if (existingName == null) {
				list = new List<string> ();
				lists.Add (fx, list); 
			} else {
				list = lists[existingName];
			}
			return list;
		}

		public static void Save ()
		{
			foreach (var kvp in lists) {
				var framework = kvp.Key;
				var list = kvp.Value.Distinct ().ToList ();

				// not generally useful but we want to keep the data sane
				var raw = $"{Helpers.Platform}-{framework}.raw";
				File.WriteAllLines (raw, list);

				// load ignore and pending files and remove them
				// 1. common.framework.ignore - long term (shared cross platforms) **preferred**
				Remove (list, $"common-{framework}.ignore");
				// 2. platform.framework.ignore - long term (platform specific) **special cases**
				Remove (list, $"{Helpers.Platform}-{framework}.ignore");
				// 3. platform.framework.pending - short term
				Remove (list, $"{Helpers.Platform}-{framework}.todo");

				var fname = $"{Helpers.Platform}-{framework}.unclassified";
				if (list.Count == 0) {
					if (File.Exists (fname))
						File.Delete (fname);
				} else {
					list.Sort ();
					File.WriteAllLines (fname, list);
				}
			}
		}

		static void Remove (IList<string> list, string file)
		{
			if (!File.Exists (file))
				return;
			foreach (var line in File.ReadAllLines (file)) {
				if (line.StartsWith ("!", StringComparison.Ordinal))
					list.Remove (line);
			}
		}
	}
}