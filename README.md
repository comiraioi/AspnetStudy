# AspnetStudy
An ASP.NET MVC demo project from [The Complete ASP.NET MVC 5 Course](https://www.udemy.com/course/the-complete-aspnet-mvc-5-course/) by Mosh Hamedani
* 강의 소스코드: [https://github.com/stefaleon/Vidly](https://github.com/stefaleon/Vidly)

<br>

---
## 00 Start the project
### 폴더 살펴보기
**App_Data**: 데이터 저장됨

**App_start**
- **BundleConfig**: JavaScript, CSS 파일을 하나의 번들로 압축하여 페이지 로드시 필요한 HTTP 요청 수를 줄여 로드 속도가 향상됨
- **RouteConfig**
  - url 패턴 설정: "{controller}/{action}/{id}"
  - 기본 경로: controller = "Home", action = "Index", id = UrlParameter.Optional
  - 
**Content**: css 파일, 부트스트랩, 이미지소스

**Controllers**: 기본 템플릿 컨트롤러 자동 생성됨
- HomeController: 메인 페이지
- Account: 가입, 로그인/로그아웃
- Manage: 사용자 프로필 관리

**Models**: 도메인 클래스 작성

**Scripts**: JavaScript 파일 저장

**Views**
- 컨트롤러명과 동일한 뷰 폴더
- 컨트롤러간 공유 가능한 뷰가 있는 Shared 폴더

**기타 파일**
- favicon.ico: 브라우저에 표시되는 애플리케이션 아이콘
- Gloval.asax: asp.net의 전통적인 파일, 애플리케이션 수명 주기의 이벤트에 대한 후크 제공?
	     애플리케이션이 시작되면 Gloval.asax.cs 파일의 Application_Start() 메서드가 호출되어 경로 지정
- packages.config: 패키지 관리자
- Startup.cs: 
- Web.config: XML configuration
  - <connectionStrings>: DB 연결 문자열을 지정함
  - <appSettings>: configuration 세팅 정의





