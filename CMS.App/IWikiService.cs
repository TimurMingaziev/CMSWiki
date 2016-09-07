using CMS.Data;

namespace CMS.App
{
    public interface IWikiService
    {

        // Созадние раздела.
        void CreateSection(SectionDto dto);
        // Создание страницы.
        void CreatePage(PageDto dto);
        // Редактирование страницы.
        void UpdatePage(PageDto dto);
        // Добавление коментария.
        void CreateComment(CommentDto dto);
        // Выставление оценки.
        void CreateMark(MarkDto dto);

    }
}
