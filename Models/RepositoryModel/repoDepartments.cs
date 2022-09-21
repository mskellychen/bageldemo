using bageldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class repoDepartments :BaseClass
{
	public IRepository<Departments> repo;

	public repoDepartments()
	{
		repo = new EFGenericRepository<Departments>(new dbEntities());
	}
}
