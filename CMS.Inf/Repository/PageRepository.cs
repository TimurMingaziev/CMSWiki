using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CMS.Data;
using CMS.Model.Domain;
using System.Data.Entity;
using NLog;

namespace CMS.Inf.Repository
{

    public class PageRepository
    {
        private readonly UserContext _userContext;
        private readonly IConfigurationProvider _config;
        private readonly ILogger _logger;

        public PageRepository(ILogger logger)
        {
            _logger = logger;
            _userContext = new UserContext();
            _config = new MapperConfiguration(cfg => cfg.CreateMap<Page, PageDto>());
        }

        public Page GetPageById(int id)
        {
            using (var context = new UserContext())
            {
                return context.Set<Page>().FirstOrDefault(x => x.PageId == id);
            }
        }

        public void CreatePage(Page page)
        {
            try
            {
                _logger.Info("Repository : {0}", "/// mapping ///");
                var dest = _config.CreateMapper().Map<Page, PageDto>(page);
                _logger.Info("Repository : {0}", "/// adding ///");
                _userContext.Page.Add(dest);
                _logger.Info("Repository : {0}", "/// saving ///");
                _userContext.SaveChanges();
                _logger.Info("Repository : {0}", " done ");

            }
            catch (Exception e)
            {
                _logger.Error(e.Source + " : " + e.Message);
                throw;
            }
            finally
            {
                _userContext.Database.Connection.Close();
            }


        }

        public void UpdatePage(PageDto dto)
        {

            try
            {
                _logger.Info("Repository : {0}", "/// changing " 
                    + dto.PageId + "  "
                    + dto.ContentPage + " ///");

                var page = _userContext.Page
                    .FirstOrDefault(c => c.PageId == dto.PageId);
                if (page != null)
                {
                    page.ContentPage = dto.ContentPage;
                    _logger.Info("Repository : {0}", "/// saving ///");
                    _userContext.Entry(page).State = EntityState.Modified;
                }
                _userContext.SaveChanges();
                _logger.Info("Repository : {0}", "/// done ///");
            }
            catch (Exception e)
            {
                _logger.Error(e.Source + " : " + e.Message);
                throw;
            }

            finally
            {
                _userContext.Database.Connection.Close();
            }
        }

    }
}
