﻿namespace MathSite.Api.Internal
{
    public static class MethodNames
    {
        public class Global
        {
            public const string GetCount = "get-count";
            public const string GetPaged = "get-all-by-page";


            public const string Create = "create";
            public const string Update = "update";
            public const string Delete = "delete";
            public const string GetOne = "get-by-id";
            
            public const string GetByAlias = "get-by-alias";
        }

        public static class Users
        {
            public const string GetAll = "get-all";
            public const string GetByLogin = "get-by-login";
            public const string GetByLoginAndPassword = "get-by-login-and-password";
            public const string HasRight = "has-right";
            public const string HasCurrentUserRight = "has-current-user-right";
            public const string GetCurrentUser = "get-current-user";
            public const string DoesCurrentUserGuest = "does-current-user-is-guest";
        }

        public static class SiteSettings
        {
            public const string GetPerPageCount = "get-per-page-count";
            public const string GetTitleDelimiter = "get-title-delimiter";
            public const string GetDefaultHomePageTitle = "get-default-home-page-title";
            public const string GetDefaultNewsPageTitle = "get-default-news-page-title";
            public const string GetSiteName = "get-site-name";

            public const string SetPerPageCount = "set-per-page-count";
            public const string SetTitleDelimiter = "set-title-delimiter";
            public const string SetDefaultHomePageTitle = "set-default-home-page-title";
            public const string SetDefaultNewsPageTitle = "set-default-news-page-title";
            public const string SetSiteName = "set-site-name";
        }

        public static class Professors
        {
        }

        public static class Files
        {
            public const string GetFileById = "get-file-by-id";
            public const string PutFile = "put-file";
            public const string GetFilesByExtensions = "get-files-by-extensions";
        }

        public static class Categories
        {
        }

        public static class Groups
        {
            public const string GetGroupsByType = "get-groups-by-type";
            public const string HasRight = "has-right";
        }

        public static class Directories
        {
            public const string MoveDirectories = "move-directories";
            public const string GetDirectoryWithPath = "get-directory-with-path";
        }

        public static class Posts
        {
            public const string GetPagesCount = "get-pages-count";
            public const string GetPosts = "get-posts";
            public const string GetPostByUrlAndType = "get-post-by-url-and-type";
        }

        public static class PostTypes
        {
            public const string GetByPostId = "get-by-post-id";
        }

        public static class PostSettings
        {
            public const string GetByPostId = "get-by-post-id";
        }

        public static class PostSeoSettings
        {
            public const string GetByPostId = "get-by-post-id";
        }

        public static class Persons
        {
            public const string GetAllWithoutUsers = "get-all-without-users";
            public const string GetAllWithoutProfessors = "get-all-without-professors";
        }

        public static class Auth
        {
            public const string GetCurrentUserId = "get-current-user-id";
            public const string GetToken = "get-token";
        }
    }
}