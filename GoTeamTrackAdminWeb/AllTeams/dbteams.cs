<?xml version="1.0" encoding="utf-8"?>
<DataSet>
  <xs:schema id="NewDataSet" xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xs:element name="NewDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true">
      <xs:complexType>
        <xs:choice minOccurs="0" maxOccurs="unbounded">
          <xs:element name="Teams">
            <xs:complexType>
              <xs:sequence>
                <xs:element name="TCode" type="xs:string" minOccurs="0" />
                <xs:element name="Password" type="xs:string" minOccurs="0" />
                <xs:element name="TeamName" type="xs:string" minOccurs="0" />
                <xs:element name="IsActive" type="xs:string" minOccurs="0" />
                <xs:element name="StartDate" type="xs:string" minOccurs="0" />
                <xs:element name="EndDate" type="xs:string" minOccurs="0" />
                <xs:element name="Remarks" type="xs:string" minOccurs="0" />
                <xs:element name="MaxUsers" type="xs:int" minOccurs="0" />
              </xs:sequence>
            </xs:complexType>
          </xs:element>
        </xs:choice>
      </xs:complexType>
    </xs:element>
  </xs:schema>
  <diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
    <NewDataSet>
      <Teams diffgr:id="Teams1" msdata:rowOrder="0">
        <TCode>AboutText</TCode>
        <Password>abcd</Password>
        <TeamName>abcd</TeamName>
        <IsActive>abcd</IsActive>
        <StartDate>abcd</StartDate>
        <EndDate>abcd</EndDate>
        <Remarks>abcd</Remarks>
        <MaxUsers>3</MaxUsers>
      </Teams>
      <Teams diffgr:id="Teams2" msdata:rowOrder="1">
        <TCode>T001</TCode>
        <Password>1234</Password>
        <TeamName>T001</TeamName>
        <IsActive>True</IsActive>
        <StartDate>2020-01-01 22:00:00</StartDate>
        <EndDate>30-09-2020</EndDate>
        <Remarks>abcd</Remarks>
        <MaxUsers>3</MaxUsers>
      </Teams>
      <Teams diffgr:id="Teams3" msdata:rowOrder="2">
        <TCode>T002</TCode>
        <Password>1234</Password>
        <TeamName>T002</TeamName>
        <IsActive>True</IsActive>
        <StartDate>2020-09-01 00:00:00</StartDate>
        <EndDate>2020-09-30 00:00:00</EndDate>
        <Remarks>abcd</Remarks>
        <MaxUsers>5</MaxUsers>
      </Teams>
      <Teams diffgr:id="Teams4" msdata:rowOrder="3">
        <TCode>T003</TCode>
        <Password>1234</Password>
        <TeamName>T 003</TeamName>
        <IsActive>True</IsActive>
        <StartDate>2020-09-02 00:00:00</StartDate>
        <EndDate>2020-09-17 00:00:00</EndDate>
        <Remarks>abcd</Remarks>
        <MaxUsers>3</MaxUsers>
      </Teams>
      <Teams diffgr:id="Teams5" msdata:rowOrder="2">
        <TCode>admin</TCode>
        <Password>admin</Password>
        <TeamName>admin</TeamName>
        <IsActive>True</IsActive>
        <StartDate>2020-09-01 00:00:00</StartDate>
        <EndDate>2020-09-30 00:00:00</EndDate>
        <Remarks>admin</Remarks>
        <MaxUsers>50</MaxUsers>
      </Teams>
    </NewDataSet>
  </diffgr:diffgram>
</DataSet>