<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <head>
        <title>Students</title>
        <style>
          h3 {
          width: 50%;
          text-align: center;
          }
          
          .main-container {
          width: 50%;
          heigth: 100%;
          margin: 10px;
          padding: 10px;
          border-radius: 5px;
          box-shadow: 5px 5px 15px 1px grey;
          }

          .exams-container {
          margin: 4px;
          padding: 2px;
          }
        </style>
      </head>
      <body>
        <h3>Students</h3>
        <xsl:for-each select="students/student">
          <div class="main-container">
            Name: <strong>
              <xsl:value-of select="name"/>
            </strong>
            <div class="exams-container">
              Exams taken:
              <xsl:for-each select="exams/exam">
                <div>
                  <xsl:value-of select="position()"/> .
                  <i>
                    <xsl:value-of select="exam-name"/>
                  </i>
                  - Score: <xsl:value-of select="score"/>
                  - Tutoring: <xsl:value-of select="tutor"/>
                </div>
              </xsl:for-each>
            </div>
          </div>
        </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
