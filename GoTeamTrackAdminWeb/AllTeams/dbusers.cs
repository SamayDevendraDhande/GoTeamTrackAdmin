<?xml version="1.0" encoding="utf-8"?>
<DataSet>
  <xs:schema id="NewDataSet" xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xs:element name="NewDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true">
      <xs:complexType>
        <xs:choice minOccurs="0" maxOccurs="unbounded">
          <xs:element name="Users">
            <xs:complexType>
              <xs:sequence>
                <xs:element name="UCode" type="xs:string" minOccurs="0" />
                <xs:element name="Password" type="xs:string" minOccurs="0" />
                <xs:element name="Name" type="xs:string" minOccurs="0" />
                <xs:element name="Email" type="xs:string" minOccurs="0" />
                <xs:element name="TCode" type="xs:string" minOccurs="0" />
                <xs:element name="IsActive" type="xs:string" minOccurs="0" />
                <xs:element name="Remarks" type="xs:string" minOccurs="0" />
              </xs:sequence>
            </xs:complexType>
          </xs:element>
        </xs:choice>
      </xs:complexType>
    </xs:element>
  </xs:schema>
  <diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
    <NewDataSet>
      <Users diffgr:id="Users1" msdata:rowOrder="0">
        <UCode>U001</UCode>
        <Password>1234</Password>
        <Name>U001</Name>
        <Email>u001@gmail.com</Email>
        <TCode>T001</TCode>
        <IsActive>True</IsActive>
        <Remarks>abcd</Remarks>
      </Users>
      <Users diffgr:id="Users2" msdata:rowOrder="1">
        <UCode>User6</UCode>
        <Password>1234</Password>
        <Name>User 6</Name>
        <Email>user6@gmail.com</Email>
        <TCode>T003</TCode>
        <IsActive>True</IsActive>
        <Remarks>abcd</Remarks>
      </Users>
      <Users diffgr:id="Users3" msdata:rowOrder="2">
        <UCode>User7</UCode>
        <Password>1234</Password>
        <Name>User 7</Name>
        <Email>user7@gmail.com</Email>
        <TCode>T003</TCode>
        <IsActive>True</IsActive>
        <Remarks>abcd</Remarks>
      </Users>
      <Users diffgr:id="Users4" msdata:rowOrder="3">
        <UCode>User8</UCode>
        <Password>1234</Password>
        <Name>User 8</Name>
        <Email>u008@gmail.com</Email>
        <TCode>T003</TCode>
        <IsActive>True</IsActive>
        <Remarks>222</Remarks>
      </Users>
        <Users diffgr:id="devendra" msdata:rowOrder="5">
        <UCode>devendra</UCode>
        <Password>devendra</Password>
        <Name>Devendra</Name>
        <Email>u008@gmail.com</Email>
        <TCode>T003</TCode>
        <IsActive>True</IsActive>
        <Remarks>222</Remarks>
      </Users>
      <Users diffgr:id="Users5" msdata:rowOrder="4">
        <UCode>System.Data.DataRow</UCode>
      </Users>
    </NewDataSet>
  </diffgr:diffgram>
</DataSet>