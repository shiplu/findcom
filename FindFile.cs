using System;
using System.Collections.Generic;
using System.Text;

namespace findcom
{
    class FindFile
    {
	
        public  string[] Find(string prefix, string suffix, string[] directories, string[] extensions)
        {
            string filename = string.Empty;
            List<string> files = new List<string>();

            foreach (string dir in directories)
            {
                foreach (string ext in extensions)
                {
                    foreach (string file in System.IO.Directory.GetFiles(dir, string.Format("*{2}", prefix, suffix, ext.ToLower())))
                    {
                        filename = System.IO.Path.GetFileNameWithoutExtension(file);
                        if(filename.StartsWith(prefix) && filename.EndsWith(suffix))
                        files.Add(System.IO.Path.GetFileName(file).ToLower());
                    }
                }
            }
            files.Sort();
            return files.ToArray();
        }

        public string[] Find(string prefix, string suffix)
        {
            return this.Find(
			                 prefix, 
			                 suffix, 
			                 this.GetEnvVariableItems(
			                                          Environment.GetEnvironmentVariable("PATH"), 
			                                          System.IO.Path.PathSeparator
			                                          ), 
			                 this.GetEnvVariableItems(
			                                          Environment.GetEnvironmentVariable("PATHEXT"), 
			                                          System.IO.Path.PathSeparator
			                                          )
			                 );
        }

        public string[] Find()
        {
            return this.Find(
			                 string.Empty, 
			                 string.Empty, 
			                 this.GetEnvVariableItems(
			                                          Environment.GetEnvironmentVariable("PATH"), 
			                                          System.IO.Path.PathSeparator
			                                          ), 
			                 this.GetEnvVariableItems(
			                                          Environment.GetEnvironmentVariable("PATHEXT"), 
			                                          System.IO.Path.PathSeparator
			                                          )
			                 );
        }
        public string[] GetEnvVariableItems(string EnvVariable, char separator)
        {
            return EnvVariable.Split(
			                         new char[] {separator}, 
									StringSplitOptions.RemoveEmptyEntries
			);
        }
    }
}
