using System.Linq;
using CMS.Data;
using CMS.Model.Domain;
using AutoMapper;
using System;
using NLog;

namespace CMS.Inf.Repository
{
    public class SectionRepository
    {
        readonly UserContext _userContext;
        readonly IConfigurationProvider _config;
        readonly ILogger _logger;
        public SectionRepository(ILogger logger)
        {
            _logger = logger;
            _userContext = new UserContext();
            _config = new MapperConfiguration(cfg => cfg.CreateMap<Section, SectionDto>());
        }
        public Section GetSectionById(int id)
        {
             return _userContext.Set<Section>().FirstOrDefault(x => x.SectionId == id);
        }

        public void CreateSection(Section section)
        {
            try
            {
                _logger.Info("Repository : {0}", "/// mapping ///");
                var dest = _config.CreateMapper().Map<Section, SectionDto>(section);
                _logger.Info("Repository : {0}", "/// adding ///");
                _userContext.Section.Add(dest);
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
    }
}
