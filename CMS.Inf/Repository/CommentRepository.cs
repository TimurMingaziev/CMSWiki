using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Data;
using CMS.Model.Domain;
using AutoMapper;
using NLog;

namespace CMS.Inf.Repository
{
    public class CommentRepository 
    {
        readonly UserContext _userContext;
        readonly IConfigurationProvider _config;
        readonly ILogger _logger;
        public CommentRepository(ILogger logger)
        {
            _logger = logger;
            _userContext = new UserContext();
            _config = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDto>());
        }

        public void CreateComment(Comment comment)
        {
            try
            {
                _logger.Info("Repository : {0}", "/// mapping ///");
                var dest = _config.CreateMapper().Map<Comment, CommentDto>(comment);
                _logger.Info("Repository : {0}", "/// adding ///");
                _userContext.Comment.Add(dest);
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
