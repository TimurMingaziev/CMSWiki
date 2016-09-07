using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Inf;
using CMS.Inf.Repository;
using CMS.Model;
using CMS.Model.Domain;
using AutoMapper;
using CMS.Data;
using NLog;

namespace CMS.App
{
    public class WikiSarvice : IWikiService
    {
        readonly PageRepository _pageRepo;
        readonly SectionRepository _sectionRepo;
        readonly CommentRepository _commentRepo;
        readonly MarkRepository _markRepo;
        readonly ILogger _logger;
         
        public WikiSarvice(ILogger logger)
        {
            _logger = logger;
            _pageRepo = new PageRepository(_logger);
            _sectionRepo = new SectionRepository(_logger);
            _commentRepo = new CommentRepository(_logger);
            _markRepo = new MarkRepository(_logger);
        }

        public void CreateComment(CommentDto dto)
        {
            try
            {
                _logger.Info("UseCase : {0}", "start create comment");
                var comment = new Comment(dto.ContentComment,dto.OwnerComment,dto.PageId){};
                _logger.Info("UseCase : {0}", "adding to repository");
                _commentRepo.CreateComment(comment);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }

        public void CreateMark(MarkDto dto)
        {
            try
            {
                _logger.Info("UseCase : {0}", "start create mark");
                var mark = new Mark(dto.MarkThis,dto.OwnerMark,dto.DateMark,dto.PageId) {};
                _logger.Info("UseCase : {0}", "adding to repository");
                _markRepo.CreateMark(mark);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

        }

        public void CreatePage(PageDto dto)
        {
            try
            {
                _logger.Info("UseCase : {0}", "start create page");
                var page  = new Page(dto.NamePage,dto.ContentPage,dto.DateCreatePage, dto.DateChangePage,
                    dto.OwnerPage,dto.ChangerPage,dto.SectionId);
                _logger.Info("UseCase : {0}", "adding to repository");
                _pageRepo.CreatePage(page);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }


        public void CreateSection(SectionDto dto)
        {
            try
            {
                _logger.Info("UseCase : {0}", "start create section");
                var section = new Section(dto.NameSection, dto.DecriptionSection, dto.OwnerSection) {};
                _sectionRepo.CreateSection(section);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }

        }

        public void UpdatePage(PageDto objDto)
        {

        }
    }
}
