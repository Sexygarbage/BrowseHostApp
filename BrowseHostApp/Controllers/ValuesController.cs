using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BrowseHostApp.Models;
using System.IO;

namespace BrowseHostApp.Controllers
{
    public class ValuesController : ApiController
    {

        public static IEnumerable<Register> directoryPath(string @currentDirectory = @"c:\")
        {
            string[] directoryPaths = Directory.GetDirectories(@currentDirectory);
            List<Register> listOfRegisters = new List<Register>();

            int id = 0;
            foreach (string directoryPath in directoryPaths)
            {
                id++;
                listOfRegisters.Add(new Register
                {
                    registerId = id,
                    registerName = directoryPath,
                    registerAccess = Directory.GetAccessControl(@directoryPath).ToString(),
                    //Access = .ToString(),
                });
                var access = listOfRegisters[listOfRegisters.Count - 1].registerAccess;
                foreach (var itemAccess in access)
                    listOfRegisters[listOfRegisters.Count - 1].registerAccess += itemAccess;
            }
            return listOfRegisters;
        }

        public static IEnumerable<String> directoryPathToString(string @currentDirectory = @"c:\")
        {
            string[] directoryPaths = Directory.GetDirectories(@currentDirectory);
            List<String> listOfRegisters = new List<String>();

            foreach (string directoryPath in directoryPaths)
            {
                listOfRegisters.Add(directoryPath);
                
            }
            return listOfRegisters;
        }

        public Repository repository = Repository.Current;
        // GET api/values
        [HttpGet]
        public string Get()
        {
            var directories = directoryPath(@"e:\");
            //foreach (var item in directories)
            //    item.Children = directoryPath(item.Name).ToList();

            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(directories);
            //return (new Folder()).GetFiles();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}