using bageldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class repoRoles : BaseClass
{
	public IRepository<Roles> repo;

	public repoRoles()
	{
		repo = new EFGenericRepository<Roles>(new dbEntities());
	}
}
