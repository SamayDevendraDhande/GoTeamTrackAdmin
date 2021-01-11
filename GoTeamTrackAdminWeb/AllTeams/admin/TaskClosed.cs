<?xml version="1.0" encoding="utf-8"?>
<DataSet>
  <xs:schema id="NewDataSet" xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xs:element name="NewDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true">
      <xs:complexType>
        <xs:choice minOccurs="0" maxOccurs="unbounded">
          <xs:element name="Ongoing">
            <xs:complexType>
              <xs:sequence>
                <xs:element name="Timestamp" type="xs:long" minOccurs="0" />
                <xs:element name="Task" type="xs:string" minOccurs="0" />
                <xs:element name="Status" type="xs:string" minOccurs="0" />
                <xs:element name= "UCode" type="xs:string" minOccurs="0" />
                <xs:element name="Name" type="xs:string" minOccurs="0" />
                <xs:element name="CreateDate" type="xs:dateTime" minOccurs="0" />
                <xs:element name="TargetDate" type="xs:dateTime" minOccurs="0" />
                <xs:element name="Remarks" type="xs:string" minOccurs="0" />
                <xs:element name="RemarksDate" type="xs:dateTime" minOccurs="0" />
              </xs:sequence>
            </xs:complexType>
          </xs:element>
        </xs:choice>
      </xs:complexType>
    </xs:element>
  </xs:schema>
  <diffgr:diffgram xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1">
    <NewDataSet>
      <Ongoing diffgr:id="Ongoing1" msdata:rowOrder="0">
        <Timestamp>637442278451908314</Timestamp>
        <Task>Sample Task</Task>
        <Status>Completed</Status>
        <UCode></UCode>
        <Name></Name>
        <CreateDate>2020-12-22T09:57:25.1908314+05:30</CreateDate>
        <TargetDate>2020-12-22T00:00:00+05:30</TargetDate>
      </Ongoing>
    </NewDataSet>
  </diffgr:diffgram>
</DataSet>