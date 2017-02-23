
## Similarities and differences between ASP.NET WebForms and ASP.NET MVC ##

**Web Forms** uses Page controller pattern approach for rendering layout. In this approach, every page has its own controller, i.e., code-behind file that processes the request.	
**MVC** uses Front Controller approach, meaning that a common controller for all the pages processes the requests.

**Web Forms** (without MVP) has no separation of concerns. 
**MVC** - very clean separation of concerns. 

**Web Forms** (without MVP) - because of this coupled behavior, automated testing is really difficult.	
**MVC** - testability is a key feature in ASP.NET MVC. 

**Web Forms** - in order to achieve stateful behavior, viewstate is used. Statefulness has a lots of problems for web environment in case of excessively large viewstate. A large viewstate means increase in page size.
**MVC** - ASP.NET MVC approach is stateless.

**Web Forms** - ASP.NET WebForms model follows a Page Life cycle.	
**MVC** - just a simple request cycle. 

**Web Forms** - along with statefulness, Microsoft tries to introduce server-side controls. This abstraction is good, yet it provides limited control over HTML, JavaScript and CSS.	
**MVC** - no server-side controls, so detailed knowledge of HTML, JavaScript and CSS is required.
