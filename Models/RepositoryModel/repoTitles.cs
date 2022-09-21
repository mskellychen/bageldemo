using bageldemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class repoTitles : BaseClass
{
	public IRepository<Titles> repo;

	public repoTitles()
	{
		repo = new EFGenericRepository<Titles>(new dbEntities());
	}
}