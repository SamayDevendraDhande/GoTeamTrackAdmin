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
                <xs:element name="UCode" type="xs:string" minOccurs="0" />
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
        <Timestamp>637442278451918314</Timestamp>
        <Task>Task1</Task>
        <Status>Status1</Status>
        <UCode>usercode1</UCode>
        <Name>Name1</Name>
        <CreateDate>2020-12-22T09:57:25.1908314+05:30</CreateDate>
        <TargetDate>2020-12-22T00:00:00+05:30</TargetDate>
      </Ongoing>
      <Ongoing diffgr:id="Ongoing2" msdata:rowOrder="1">
        <Timestamp>637441642123643329</Timestamp>
        <Task>Task1</Task>
        <Status>Closed</Status>
        <UCode>usercode1</UCode>
        <Name>Name1</Name>
        <CreateDate>2020-12-21T16:16:42.3653533+05:30</CreateDate>
        <TargetDate>2020-12-21T00:00:00+05:30</TargetDate>
      </Ongoing>
      <Ongoing diffgr:id="Ongoing3" msdata:rowOrder="2">
        <Timestamp>637441647913166644</Timestamp>
        <Task>Task6</Task>
        <Status>Closed</Status>
        <UCode>User8</UCode>
        <Name>User 8</Name>
        <CreateDate>2020-12-21T00:00:00+05:30</CreateDate>
        <TargetDate>2020-12-31T00:00:00+05:30</TargetDate>
        <Remarks>aaa</Remarks>
        <RemarksDate>2020-12-31T00:00:00+05:30</RemarksDate>
      </Ongoing>
      <Ongoing diffgr:id="Ongoing4" msdata:rowOrder="3">
        <Timestamp>637442303509347780</Timestamp>
        <Task>Task8</Task>
        <Status>Completed</Status>
        <UCode>User8</UCode>
        <Name>User 8</Name>
        <CreateDate>2020-12-22T00:00:00+05:30</CreateDate>
        <TargetDate>2020-12-31T00:00:00+05:30</TargetDate>
      </Ongoing>
      <Ongoing diffgr:id="Ongoing5" msdata:rowOrder="4">
        <Timestamp>637442290226535464</Timestamp>
        <Task>Task7</Task>
        <Status>Completed</Status>
        <UCode>User8</UCode>
        <Name>User 8</Name>
        <CreateDate>2020-12-22T00:00:00+05:30</CreateDate>
        <TargetDate>2020-12-31T00:00:00+05:30</TargetDate>
        <Remarks>asdf asdf 24</Remarks>
        <RemarksDate>2020-12-25T00:00:00+05:30</RemarksDate>
      </Ongoing>
    </NewDataSet>
  </diffgr:diffgram>
</DataSet>