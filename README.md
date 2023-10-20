# AspnetStudy
An ASP.NET MVC demo project from [The Complete ASP.NET MVC 5 Course](https://www.udemy.com/course/the-complete-aspnet-mvc-5-course/) by Mosh Hamedani
* 강의 소스코드: [https://github.com/stefaleon/Vidly](https://github.com/stefaleon/Vidly)
* ASP.NET MVC 5 기초 사이트
* : [https://www.tutorialsteacher.com/mvc](https://www.tutorialsteacher.com/mvc) / [https://thebook.io/006824/](https://thebook.io/006824/)(25장부터)

<br>

---
## 폴더 살펴보기
__* App_Data__: 데이터 저장됨

__* App_start__
- **BundleConfig**: JavaScript, CSS 파일을 하나의 번들로 압축하여 페이지 로드시 필요한 HTTP 요청 수를 줄여 로드 속도가 향상됨
- **RouteConfig**
  - url 패턴 설정: "{controller}/{action}/{id}"
  - 기본 경로: controller = "Home", action = "Index", id = UrlParameter.Optional
  - 

__* Content__
: css 파일, 부트스트랩, 이미지소스

__* Controllers__
: 기본 템플릿 컨트롤러 자동 생성됨
- HomeController: 메인 페이지
- Account: 가입, 로그인/로그아웃
- Manage: 사용자 프로필 관리
  
__* Models__
: 도메인 클래스 작성
- IdentityModels: context 메서드에 DBset 추가

__* Scripts__
: JavaScript 파일 저장

__* Views__
- 컨트롤러명과 동일한 뷰 폴더
- 컨트롤러간 공유 가능한 뷰가 있는 Shared 폴더
  
__* 기타 파일__
- favicon.ico: 브라우저에 표시되는 애플리케이션 아이콘
- Gloval.asax: asp.net의 전통적인 파일, 애플리케이션 수명 주기의 이벤트에 대한 후크 제공?
	     애플리케이션이 시작되면 Gloval.asax.cs 파일의 Application_Start() 메서드가 호출되어 경로 지정
- packages.config: 패키지 관리자
- Startup.cs: 
- Web.config: XML configuration
  - <connectionStrings>: DB 연결 문자열을 지정함
  - <appSettings>: configuration 세팅 정의
  
<br>

---
## MVC 아키텍처
### MVC
- **Model**: 애플리케이션 데이터
- **View**: 사용자에게 보여주는 HTML 마크업 페이지
- **Controller**: HTTP 요청을 처리
- **Router**: HTTP 요청별 적합한 컨트롤러(액션)을 선택함

### Model
Model 클래스 생성: Models 폴더 > 추가 > 새 항목 > 클래스파일
```
// public 단축어: prop
public 타입 프로퍼티명 {get; set;}	// Java의 Getter, Setter 메서드
```

### Controller
Controller 파일 생성: Controllers 폴더 우클릭 > 추가 > 컨트롤러
- 컨트롤러를 생성하면 Index 액션 메서드가 디폴트로 있음
- 메서드에서 모델의 인스턴스 생성하기
  ```
  var 변수명 = new 모델명() { 속성명 = "값" }
  ```

### View
View 파일 생성: 컨트롤러명과 동일한 뷰 폴더 우클릭 > 추가 > 레이아웃이 있는 MVC5 뷰 페이지 > 뷰 이름 메서드명과 동일하게 작성
- 뷰 페이지명 설정: ViewBag.Title = "페이지명";
- 모델 속성 뷰에 출력하기
  ```
  /* 모델 클래스의 정규화된 이름을 지정 */
  @model 애플리케이션명.Models.모델클래스명 // 최상단에 작성
  
  @Model.속성명: 컨트롤러에서 모델에 대한 액세스를 제공
  ```
- 부트스트랩 테마 변경하기
  1. https://bootswatch.com/ > Themes > Lumen > bootstrap.css 다운로드
  2. Content 폴더에 bootstrap-lumen.css로 파일명 변경해서 저장
  3. App_Start > BundleConfig.cs > StyleBundle의 부트스트랩 파일명 변경

<br>

---
## Action
### Action Results 타입별 헬퍼 메서드
- ViewResult - **View(객체)**: ASP.NET MVC의 모든 작업 결과물에 대한 기본 클래스, 액션에서 파생된 클래스의 인스턴스를 반환
- PartialViewResult - **PartialView()**: 부분적인 뷰 컨텐츠 결과를 반환
- ContentResult - **Content()**: 간단한 텍스트 반환
- RedirectResult - **Redirect()**: URL 반환
- RedirectToRouteResult - **RedirectToACtion()**: URL 대신 액션 반환
- JsonResult - **Json()**: Json 객체 반환
- FileResult - **File()**: 파일 반환
- **HttpNotFountResult**: not found 404 에러 반환
- **EmptyResult**: void와 같이 값을 반환할 필요가 없을 때 (헬퍼 메서드 없음) 	ex) return new EmptyResult();

### Action Parameters
: url로 매개변수에 값 넘겨서 뷰에 출력하기
- url 요청: https://localhost:44368/컨트롤러명?매개변수1=값1&매개변수2=값2
- 액션 메서드 작성
  ```
  public ActionResult 메서드명(타입 매개변수1, 타입 매개변수2)
  {
     /* 기본값을 설정하면 url 요청 시 컨트롤러만 작성하고 매개변수를 넘기지 않아도 오류가 발생하지 않음 */
      if (!pageIndex.HasValue)    //pageIndex에 값이 없으면
          pageIndex = 1;          //기본값 1

      if (String.IsNullOrEmpty(sortBy))   //sortBy가 Null이거나 Empty면
          sortBy = "Title";               //기본값 Title
  
      return Content(String.Format("매개변수1={0}&매개변수2={1}", 매개변수1, 매개변수2));
  }
  ```

<br>

---
## Routing 
### Convention-based Routing
- 라우팅 형식: {controller}/{action}/{id}
- 사용자 지정 라우팅: 기본 라우팅 상단에 작성해야함
  ```
  routes.MapRoute(
      "경로명",
      "액션명/{매개변수1}/{매개변수2}",	//url 패턴
      new { controller = "컨트롤러명", action = "메서드명" },	//익명 개체로 기본값 설정
      new {매개변수1 = @"", 매개변수2 = @"" }	//제약 조건 설정  ex)정규식
  );
  ```

### Attribute Routing (속성 라우팅)
- 참고: [https://devblogs.microsoft.com/dotnet/attribute-routing-in-asp-net-mvc-5/](https://devblogs.microsoft.com/dotnet/attribute-routing-in-asp-net-mvc-5/)
- 속성 라우팅: routes.MapMvcAttributeRoutes();
- 컨트롤러에서 속성 라우팅 적용 및 url 템플릿 정의하기
  ```
  [Route("액션명/{매개변수1}/{매개변수2:regex(제약조건)}")]	// 메서드 상단에 작성
  public ActionResult 액션명(){
  
  }
  ```

<br>

---
## View에 데이터 출력하기
* 참고: https://m.cafe.daum.net/aspdotnet/Oyix/112
  
### [방법1] 모델 속성
```
// 모델 속성에 값을 할당하여 객체 생성
var 변수명 = new 모델명() { 속성1 = 값1, 속성2 = 값2, ... , 속성n = 값n };

//뷰에 객체 넘기기
return View(변수명); 	// 뷰: @Model.속성명
```
    
### [방법2] View Data
```
// ViewData에 값을 모델 객체를 담
모델명 변수명 = new 모델명() {속성1 = 값1, 속성2 = 값2, ... , 속성n = 값n};
ViewData["모델명"] = 변수명;

//뷰에 객체 넘기기
return View(변수명); 	// 뷰: @( ((모델명) ViewData["모델명"].속성명 ) )
```

### [방법3] View Bag
```
// ViewBag을 통해 속성에 값을 할당하기
ViewBag.속성1 = 값1;
ViewBag.속성2 = 값2;
 
return View();	//뷰: @ViewBag.모델명.속성명
```

### [방법4] View Models
뷰를 위해 만들어진 모델로 해당 뷰에 관한 데이터와 규칙을 포함함 (모델 두개를 넘길 수 있음)
- 뷰 모델 생성: ViewModels 폴더 생성 > 모델 클래스 추가하기
- 뷰가 특정 모델이 아닌 복합 모델 객체를 담은 뷰모델을 참조하도록 하여 여러 모델의 속성을 불러올 수 있음 <br>
  ex) @model 프로젝트명.Models.모델명 > @model 프로젝트명.ViewModels.뷰모델명 (뷰 상단의 참조 모델을 뷰 모델로 수정)
  - 뷰 모델
    ```
    public class 뷰모델명
    {
        /*
        IEnumerable > List
        - IEnumerable: Collection의 요소들을 반복하고 싶을 때, read-only 접근만 필요한 경우
                       foreach loop 대신 GetEnumerater()로 IEnumerator를 return 받아 MoveNext(), Current로 대체할 수 있음
        - List: Collection 요소들의 순서와 위치를 관리하고 데이터를 변형(추가,수정,삭제)하고 싶을 때
                (뷰에서는 List에서 제공하는 기능들이 필요하지 않음)
        */
        public 모델1 변수명 { get; set; }
        public IEnumerable<모델2> 변수명 { get; set; }	// 모델1이 모델2를 참조함
    }
    ```
  - 뷰 모델에 입력받은 데이터는 컨트롤러에서 [모델 바인딩](https://github.com/comiraioi/AspnetStudy/edit/master/README.md#model-binding)을 통해 뷰 모델 안의 모델 객체로 넣을 수 있음
<br>

---
## Razor
ASP.NET MVC에서 지원하는 뷰 엔진으로 HTML 및 서버 측 코드(C#)를 혼합하여 작성 가능함
(.cshtml 의 Razor View 파일 확장자를 가지고 있음)

### Razor Syntax
- @: @ 기호로 시작하여 HTML 뷰에 서버측 C# 코드를 작성할 수 있음
- @{}: 중괄호로 코드 블록을 묶을 수 있으며 블록 내의 각 코드 문은 세미콜론(;)으로 종료
- if~else 코드 블록은 단일문에 대해서도 중괄호로 감싸야함
- @변수: 코드 블록에서 변수를 선언하고 값을 삽입한 후 출력할 수 있음
- @**@: 주석 처리

### html class 속성 동적 처리 예시
```
@{
    var className = Model.모델명.Count > 5 "popular" : null;	//모델 객체가 5 이상이면 className = "popular"
}

<style>
    .popular {
        color: blue;
    }
</style>

<h2 class="@className">@Model.모델명.속성명</h2>	//클래스명이 "popular"인 경우 class style 적용됨
```

<br>

---
## Partial Views
Shared 폴더의 _Layout 뷰 파일을 부분적으로 나눌 수 있음 (ex) 네비게이션)
- 뷰 파일 불러오기: @Html.Partial("파일명")
- 뷰 파일과 뷰 모델 불러오기
  - 상단에 모델 지시문 작성: @model 솔루션명.ViewModels.뷰모델명
  - @Html.Partial("파일명", Model.모델명)

<br>

---
## Entity Framework
DB에 정확히 접근하기 위해 사용하는 O/RM(Object/Relational Mapper) 도구
- **DBContext**: 한 개 이상의 DBset 제공 ex) table
- **LINQ**: DbSet을 쿼리하는데 사용

### 엔티티 프레임워크 모델
- **Database First**: DB 테이블의 구조를 먼저 정의하고 일치하는 도메인 클래스를 생성하는 프레임워크를 가짐
- **Code First**: 도메인 클래스를 생성하고 클래스의 속성을 테이블의 컬럼에 매핑함
  - 장점: 생산성 향상, 코드 이전 및 관리가 쉬움, 통합 테스트가 쉬워짐

<br>

---
## Migration(Code-first)
클래스를 추가하거나 수정하여 도메인 모델을 수정할 때 마이그레이션을 생성하고 DB에서 실행함
- 활성화: NuGet 패키지 관리자 > 패키지 관리자 콘솔 > enable-migrations 입력 (Migrations 폴더 생성됨)
- 추가: add-migration 마이그레이션명 (마이그레이션 클래스 파일 생성됨)
- git의 코드 레포지토리처럼 부분적으로 수정하고 커밋해야 실패 확률을 줄일 수 있음

### DbSet 
: DbSet에 추가해야 모델이 DB에 연결됨
- Models 폴더 > IdentityModels.cs > IdentityDbContext<ApplicationUser> 클래스에 DbSet 추가
```
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<모델명> 테이블명 { get; set; }
    public DbSet<모델명> 테이블명 { get; set; }
}
```

### 테이블 생성
모델 생성 > IdentityModels.cs에 DBset 추가 > add-migration 마이그레이션명 > update-database

### 테이블 칼럼 추가 또는 제약조건 수정
모델에 속성 추가 or 제약조건 추가 > add-migration 마이그레이션명 > update-database
- Data Annotations: **[]**
  - NOT NULL: **Required**
  - 문자열 길이 제한: **StringLength(길이)**
 
### DB에 데이터 직접 추가하기
add-migration 마이그레이션명 >열린 마이그레이션 파일의 Up()메서드 안에 SQL 메서드로 쿼리문 작성 > update-database
```
public override void Up()
{
    테이블명(칼럼1, 칼럼2, ... , 칼럼n) VALUES (값1, 값2, ... , 값n)");
}
```

### 컨트롤러에서 DB에 접근하기
```
private ApplicationDbContext _context;  //DB에 접근

 public CustomersController()	//생성자
{
    _context = new ApplicationDbContext();
}

protected override void Dispose(bool disposing)	//Dispose 메서드
{
    _context.Dispose();
}

public ViewResult 액션명()	//액션 메서드
{
    /* DB에 있는 데이터 확보: 뷰에서 객체가 반복될 떄 쿼리가 실제로 실행됨 */
    var 변수명 = _context.테이블명.Include(x => x.참조모델).ToList();	// ToList(): List<T> 형태로 반환
    return View(변수명);
}
```

<br>

---
## 람다식과 Enumerable 확장 메서드
### 람다식
- 장점: 간결하고 가독성이 높은 코드, 코드의 재사용성 및 유지보수성 높임, 효율적인 메모리 사용
- 형식
  - 식 람다: (입력 매개변수) => 식 EX) x => x+1
  - 문 람다: (입력 매개변수) => { 문; } EX) x => { return x+1; }
 
### Enumerable 확장 메서드
- **Where(변수 => 조건)**
  - **ToList()**: 반환 형식을 List<T> 형태로 받기
  - 조건 판단 메서드: **All()** / **Any()**
- 컬렉션에서 조건에 맞는 값을 단 하나만 가져오기
  - **Single()**: null값이면(데이터가 없으면) 예외(에러) 발생
  - **SingleOrDefault()**: 값이 없으면(없는 데이터 요청 시) null 값 반환
- **Include()**: 쿼리 결과에 포함할 관련 개체를 지정함

<br>

---
## Form
### Form 생성
- __Html.BeginForm()__: <form> 태그를 자동으로 만들어주는 헬퍼 메서드
- url은 언제든 변경이 가능하기 때문에 헬퍼 메서드를 사용하게 되면 변경된 URL에 맞게 속성이 재지정됨
  ```
  @using (Html.BeginForm("액션명","테이블명"))
  {
  
  }
  ```

### Html Helper
- Html Helper는 모두 @Html 으로 시작
- @: Razor 문법으로 View 클래스(WebViewPage)의 Html 속성을 호출한다는 의미
- 모델 데이타 혹은 View 데이타 바인딩을 쉽게 할 수 있는 기능을 제공
- __메서드 타입__
  - Weakly Typed 메서드: Html.TextBox()와 같은 형태
    ```
    /* <input class="form-control" id="Name" name="Name" type="text" value=""/> */
    
    @Html.TextBox("Name", null, new {@ class = "form-control"})
    // 첫번째 파라미터: 모델의 Name 속성을 사용한다는 의미
    // 두번째 파라미터: TextBox의 Value, null이면 모델명.Name
    // 세번째 파라미터: HTML의 기타 attributes
    ```
  - Strongly Typed 메서드: Html.TextBoxFor()와 같은 형태
    ``` 
    @Html.TextBoxFor(m -> m.Name, new {@ class = "form-control"})
    // 첫번째 파라미터: 람다식, 입력: m = 모델 / 출력: m.Name = 모델명.Name
    // 두번째 파라미터: TextBox의 Value, null이면 모델명.Name	(생략 가능)
    // 세번째 파라미터: HTML의 기타 attributes
    ```
- __Html Helper 메서드__ <br>
``` @Html.메서드명(m => m.모델명.속성명, new { @class = "템플릿" }) ``` <br>
__[입력 요소]__
  - Html.TextBox / __Html.TextBoxFor__: 문자열 입력받기 (```<input type="text">```)
    * Datetype 포맷 설정은 템플릿 앞 파라미터로 작성 &nbsp; Ex) "{0:yyyy-MM-dd}"
  - Html.TextArea / __Html.TextAreaFor__: 문자열 여러줄 입력받기 (```<textarea>```)
  - Html.CheckBox / __Html.CheckBoxFor__: ```<input type="checkbox">```
  - Html.ListBox / __Html.ListBoxFor__: 리스트 형태의 체크박스
  - Html.RadioButton / __Html.RadioButtonFor__: ```<input type="radiobutton">```
  - Html.DropDownList / __Html.DropDownListFor__: ```<select><option>``` <br>
    ```
    // DropDownList 초기화: new SelectList()
    @Html.DropDownListFor(m => m.모델명.속성명, new SelectList(Model.모델명, "값을 담은 속성명", "default 옵션", "텍스트로 보여질 속성명"), new { @class = "템플릿" })
    ```
  - Html.Hidden / __Html.HiddenFor__: 뷰에 출력하지 않고 값 전달 (```<input type="hidden">```)
  - Password / __Html.PasswordFor__: ```<input type="password">```
  - Html.Editor / __Html.EditorFor__: 모델 속성의 데이터 타입에 따라 입력받기 <br>
  		Html.EditorForModel: 모델 전체에 입력받기 (```<input type="">```)
    ```
    //DataType		//HtmlElement
    string			<input type="text">
    int			<input type="number">
    decimal, float		<input type="text">
    boolean			<input type="checkbox">
    Enum			<input type="text">
    DataTime		<input type="datatime">
    ```
  __[데이터 출력]__
  - Html.Display / __Html.DisplayFor__: 모델 속성값 출력 <br>
  		 Html.DisplayForModel: 모델 전체 출력 <br>

  __[기타]__
  - Html.Label / __Html.LabelFor__: 라벨 설정 (```<label for="아이디">```) <br>
    __*__ 모델 클래스에서 속성에 __Display(Name = "라벨명")__ 을 추가해 라벨명 설정 가능 <br>
&nbsp; (라벨명을 변경하고 싶을 때 뷰가 아닌 모델 클래스에서 바꿔주어야 한다는 단점이 있음)
  - __Html.ActionLink__: 액션 링크 및 버튼 설정 (```<a href="">```)
    ```
    //버튼인 경우 템플릿에 "btn" 
    @Html.ActionLink("텍스트", "액션명", "컨트롤러명", new {매개변수명 = Model.속성명}, new { @class = "템플릿" })
    ```
    
### Form Page
- 폼에 출력할 속성이 여러 모델의 속성인 경우 [뷰모델](https://github.com/comiraioi/AspnetStudy/edit/master/README.md#%EB%B0%A9%EB%B2%954-view-models)을 별도로 생성
- Insert Form Page로 이동하는 액션 메서드
  ```
  public ActionResult 액션명()
  {
      /* DropDownList option을 출력하기 위해 DB에서 가져오기 */
      var db데이터 = _context.테이블명.ToList();	//뷰에 출력할 데이터를 가져옴
  
      var viewModel = new 뷰모델명
      {
          테이블명 = db데이터	//DB에서 가져온 참조 데이터를 모델에 담기
      };

      return View("Form뷰명",viewModel);
  }
  ```
- Update Form Page로 이동하는 액션 메서드
  ```
  public ActionResult 액션명(매개변수)	//액션링크 파라미터로 받은 고객 아이디
  {
      // 파라미터로 넘어온 아이디와 일치하는 레코드 데이터 가져오기
      var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

      if(customer == null)
          return HttpNotFound();

      // 뷰모델로 복합모델 넘기기
      var viewModel = new CustomerFormViewModel 
      { 
          Customer = customer,    //모델 객체에 id가 일치하는 레코드의 데이터 담기
          MembershipTypes = _context.MembershipTypes.ToList()
      };

      return View("Form뷰명", viewModel);
  }
  ```

### Form Data
- __Model Binding__: Http로 전송된 데이터를 C#의 모델 클래스에 담아 액션 메서드에 전달하는 기법
  - Http 요청 데이터를 직접 .NET 개체와 매핑해주는데 폼 컬렉션과 쿼리 스트링을 분석하여 액션 메서드의 매개 변수에 매핑해주는 기능을 제공함
  - HttpPost 방식 액션 메서드의 매개변수를 C# 클래스인 모델 클래스 형태로 묶어 전달 받을 수 있도록 내부적으로 처리해주는 기능
  - 모델 바인딩을 사용하면 여러 개의 매개 변수를 처리해야 하는 액션 메서드에서 모델 클래스만 지정함으로써 한 번에 여러 데이터를 그 형태에 맞게 받을 수 있음
- __HttpPost 액션 메서드__ <br>
  : Form의 항목이 복합 모델 속성인 관계로 [뷰모델](https://github.com/comiraioi/AspnetStudy/edit/master/README.md#%EB%B0%A9%EB%B2%954-view-models)을 생성해 입력받았다 할지라도 <br>
  &nbsp; __모델 바인딩__ 을 통해 매개변수를 뷰모델 안의 모델 객체로 작성하여 해당 모델에 데이터를 받을 수 있음
  ```
  [HttpPost]
  public ActionResult 액션명(모델명 변수명)  // 매개변수 모델 바인딩
  {
      /*
      [Form에서 Submit한 데이터 확인하기]
      return에 F9로 중단점 설정 > F5로 디버거 실행 > Form 페이지 url 요청(Customer/New)
      > 페이지 검사 > Network > 요청명(Create) 클릭 > Payload에서 Form Data 확인 가능
      */

      _context.테이블명.Add(모델변수명);   // 매개변수로 받은 데이터 DB에 insert
      _context.SaveChanges();     // commit tran

      return RedirectToAction("액션명", "컨트롤러명");	// 리스트 페이지로 돌아가기
  }
  ```

<br>

---
## 컨트롤러에서 DB 작업하기
### 데이터 조회: ToList()
```
var 객체명 = _context.테이블명.ToList();
var 객체명 = _context.테이블명.Include(m => m.참조모델명).ToList();	// 조회할 테이블이 다른 테이블을 참조하는 경우
```

### 데이터 추가: Add()
```
_context.Customers.Add(모델객체);
_context.SaveChanges();     // commit tran
```

### 데이터 수정
1. 아이디로 일치하는 레코드 찾기
  ```var modelInDb = _context.테이블명.SingleOrDefault(m => m.Id == 파라미터로받은모델.Id);```
2. 수정하기
  - 방법1: ```TryUpdateModel(customerInDb, "", new string[] {"업데이트할속성1","속성2",...});	//보안에 취약하다는 단점```
  - 방법2: ```Mapper.Map(파라미터모델,modelInDb) ```
  - 방법3
    ```
    /* 수동으로 매핑 */
    modelInDb.속성명1 = 파라미터모델.속성명1;
    modelInDb.속성명2 = 파라미터모델.속성명2;
    ```
3. 저장하기: ```_context.SaveChanges();```

### 데이터 삭제: Remove()
```
var modelInDb = _context.테이블명.SingleOrDefault(m => m.Id == 파라미터로받은모델.Id);	//아이디로 일치하는 레코드 찾기
_context.Customers.Remove(modelInDb);
_context.SaveChanges();
```

<br>

---
## 변수와 상수
- 변수(Variable): 값을 저장할 수 있는 메모리 내 저장소에 부여하는 이름
  - 선언: ```자료형 변수명;		// 초기화하지 않은 변수는 사용할 수 없음``` 
- 상수(Constant): 변경이 불가능한 값 (안정성)
  - 선언: ```const 자료형 변수명 = 값;	// 값을 할당하지 않은 상수는 사용할 수 없음```

### 식별자 생성 규칙
: 숫자로 시작할 수 없음, 예약어 사용 불가, 의미있는 이름으로 작성
- 네이밍 컨벤션 (Naming Convention)
  - 카멜 케이스(Camel Case): **f**irst**N**ame	&nbsp;&nbsp;=> **지역 변수** ex) ```int totalNumber;```
  - 파스칼 케이스(Pascal Case): **F**irst**N**ame	&nbsp;&nbsp;=> **상수** ex) ```const int MaxZoom = 5;```
  - 헝가리안(Hungarian Notation): strFirstName	&nbsp;&nbsp;=> C#에서는 사용 X

### 자료형 (C# Type / .NET Type)
__[원시 자료형 (Primitive Type)]__
- 정수
  - byte / Byte : 1Bytes, 0~255
  - short / Int16: 2Bytes, -32768~32767
  - int / Int32: 4Bytes, -2.1B~2.1B
- 실수
  - long / Int64: 8Bytes
  - float / Single: 4Bytes	```float number = 1.2f		//'f'붙이지 않으면 2(double형)로 처리함```
  - double / Double: 8Bytes
  - decimal / Decimal: 16Bytes	```decimal number = 1.2m```
- 캐릭터
  - char / Char: 2Bytes, 유니코드 문자
- 불
  - bool / Boolean: 1Bytes, True/False
__[참조 자료형 (Reference Type)]__
: String, Array, Enum, Class

### 오버플로우 (Overflowing)




