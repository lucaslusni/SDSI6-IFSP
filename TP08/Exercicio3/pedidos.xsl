<?xml version="1.0" encoding="ISO-8859-1" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="html" encoding="UTF-8" indent="yes"/>

    <xsl:template match="/">
        <html>
        <head>
            <title>Lista de Pedidos</title>
        </head>
        <body>
            <h1>Pedidos com Quantidade > 10</h1>
            <table border="1">
                <tr>
                    <th>Produto</th>
                    <th>Quantidade</th>
                    <th>Preco</th>
                </tr>
                <xsl:for-each select="pedidos/pedido[quantidade > 10]">
                    <tr>
                        <td><xsl:value-of select="produto"/></td>
                        <td><xsl:value-of select="quantidade"/></td>
                        <td><xsl:value-of select="preco"/></td>
                    </tr>
                </xsl:for-each>
            </table>
        </body>
        </html>
    </xsl:template>
</xsl:stylesheet>
