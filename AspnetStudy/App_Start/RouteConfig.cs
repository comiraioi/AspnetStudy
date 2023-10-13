using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspnetStudy
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /* 라우팅 유형
            [속성 라우팅] 
            routes.MapMvcAttributeRoutes();

            [사용자 지정 라우팅] 기본 경로 위에 작성
            routes.MapRoute(
                "MoviesByReleasedDate", //경로명
                "movies/released/{year}/{month}",   //매개변수
                new { controller = "Movies", action = "ByReleaseDate" },   //기본값
                new { year = @"2020|2021", month = @"\d{2}" });     //제약조건 > year은 2020 또는 2021 / month는 2자리 수 
            */

            /* 기본 경로 */
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",  
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
