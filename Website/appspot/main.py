import webapp2
from google.appengine.ext.webapp import template

class IndexHandler(webapp2.RequestHandler):
    def get(self):
        lang = "en"
        # Sprachweiche
        if self.request.headers.has_key("Accept-Language"):
            hlang = self.request.headers["Accept-Language"][0:2]
            if hlang.lower() == "de": lang = "de"

        self.redirect(lang)

class IndexHandlerDe(webapp2.RequestHandler):
    def get(self):
        self.response.headers.add_header("Content-Language", "de")
        self.response.out.write(template.render("templates/index_de.html", {}))

class IndexHandlerEn(webapp2.RequestHandler):
    def get(self):
        self.response.headers.add_header("Content-Language", "en")
        self.response.out.write(template.render("templates/index.html", {}))

application = webapp2.WSGIApplication([
	('/',     IndexHandler),
	('/de',   IndexHandlerDe),
    ('/en',   IndexHandlerEn),
], debug=True)

