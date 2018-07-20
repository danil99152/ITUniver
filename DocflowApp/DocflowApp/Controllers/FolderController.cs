using DocflowApp.Files;
using DocflowApp.Models;
using DocflowApp.Models.Filters;
using DocflowApp.Models.Repositories;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocflowApp.Controllers
{
    [Authorize]
    public class FolderController : BaseController
    {
        protected FolderRepository folderRepository;
        
        public FolderController(UserRepository userRepository, IFileProvider[] fileProviders, FolderRepository folderRepository) : base(userRepository, fileProviders)
        {
            this.userRepository = userRepository;
            this.folderRepository = folderRepository;
        }

        public ActionResult Index(long? root = null)
        {
            User user = CurrentUser;
            var filter = new FolderFilter
            {
                User = user,
                Root = root.HasValue ? folderRepository.Load(root.Value) : null
            };
            var folders = folderRepository.Find(filter);
            return View(new FolderViewModel {
                Folders = folders,
                Entity = filter.Root
            });
        }

        public ActionResult Create(long? root = null)
        {
            var model = new FolderViewModel
            {
                Entity = new Folder(),
                ParentFolder = root ?? null
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(FolderViewModel model)
        {
            if (ModelState.IsValid)
            {               
                model.Entity.Root = model.ParentFolder.HasValue ?
                    folderRepository.Load(model.ParentFolder.Value) : null;
                folderRepository.Save(model.Entity);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(long Id)
        {
            var entity = folderRepository.Load(Id);
            folderRepository.InvokeInTransaction(() => folderRepository.Delete(entity));
            return RedirectToBackUrl();
        }
    }
}