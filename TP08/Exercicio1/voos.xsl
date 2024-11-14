<?xml version="1.0" encoding="UTF-8"  ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="html" encoding="UTF-8" indent="yes"/>

    <xsl:template match="/">
        <html>
        <head>
            <title>Lista de Voos</title>
            <style>
                table { border-collapse: collapse; width: 80%; margin: 20px auto; }
                th, td { border: 1px solid #ddd; padding: 8px; text-align: center; }
                th { background-color: #4CAF50; color: white; }
                .operando-sim { color: green; font-weight: bold; }
                .operando-nao { color: red; font-weight: bold; }
            </style>
        </head>
        <body>
            <h1>Lista de Voos</h1>
            <table>
                <tr>
                    <th>Codigo</th>
                    <th>Origem</th>
                    <th>Destino</th>
                    <th>Horario</th>
                    <th>Compania</th>
                    <th>Operando</th>
                </tr>
                <xsl:for-each select="movimento/voo">

                    <xsl:sort select="@codigo" order="ascending"/>
                    <tr>
                        <td><xsl:value-of select="@codigo"/></td>
                        <td><xsl:value-of select="origem"/></td>
                        <td><xsl:value-of select="destino"/></td>
                        <td><xsl:value-of select="horario"/></td>
                        <td><xsl:value-of select="compania"/></td>

                        <td>
                            <xsl:choose>
                                <xsl:when test="operando='T'">
                                    <span class="operando-sim">SIM</span>
                                </xsl:when>
                                <xsl:otherwise>
                                    <span class="operando-nao">NAO</span>
                                </xsl:otherwise>
                            </xsl:choose>
                        </td>
                    </tr>
                </xsl:for-each>
            </table>
        </body>
        </html>
    </xsl:template>
</xsl:stylesheet>
