<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/ArrayOfOrder">
		<html>
			<head>
				<title>Order</title>
			</head>
			<body>
				<ul>
					<xsl:for-each select="Order">
					<br>Order Information</br>
						<li>
						<br>order number:</br>
							<xsl:value-of select="orderNumber" />
						<br>guest name:</br>
							<xsl:value-of select="guestName" />
						<br>guest phone:</br>
							<xsl:value-of select="guestPhone" />
						
							<xsl:for-each select="orderDetail">
							<br>order detail information:</br>
					            <xsl:for-each select="OrderDetail">
						            <li>
									<br>good Id:</br>
							            <xsl:value-of select="goodId" />
									<br>good name:</br>
							            <xsl:value-of select="goodName" />
									<br>good number:</br>
							            <xsl:value-of select="goodNumber" />
									<br>single price:</br>
								        <xsl:value-of select="singlePrice" />	
						            </li>
						        </xsl:for-each>
					        </xsl:for-each>
						</li>
					</xsl:for-each>	
				</ul>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
