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
      <Ongoing diffgr:id="Ongoing2" msdata:rowOrder="0">
        <Timestamp>637441642023643330</Timestamp>
        <Task>Task1</Task>
        <Status>Closed</Status>
        <UCode>User8</UCode>
        <Name>User 8</Name>
        <CreateDate>2020-12-21T16:16:42.3653533+05:30</CreateDate>
        <TargetDate>2020-12-21T00:00:00+05:30</TargetDate>
      </Ongoing>
      <Ongoing diffgr:id="Ongoing3" msdata:rowOrder="1">
        <Timestamp>637442303600314057</Timestamp>
        <Task>Task8</Task>
        <Status>Unallocated</Status>
        <UCode>User7</UCode>
        <Name>User7</Name>
        <CreateDate>2020-12-22T00:00:00+05:30</CreateDate>
        <TargetDate>2020-12-31T00:00:00+05:30</TargetDate>
      </Ongoing>
      <Ongoing diffgr:id="Ongoing4" msdata:rowOrder="2">
        <Timestamp>637442303680943441</Timestamp>
        <Task>Task9</Task>
        <Status>Unallocated</Status>
        <UCode>User7</UCode>
        <Name>User7</Name>
        <CreateDate>2020-12-22T00:00:00+05:30</CreateDate>
        <TargetDate>2020-12-31T00:00:00+05:30</TargetDate>
      </Ongoing>
      <Ongoing diffgr:id="Ongoing5" msdata:rowOrder="3">
        <Timestamp>637441647913163935</Timestamp>
        <Task>Task5</Task>
        <Status>Unallocated</Status>
        <UCode>User6</UCode>
        <Name>User6</Name>
        <CreateDate>2020-12-21T00:00:00+05:30</CreateDate>
        <TargetDate>2020-12-31T00:00:00+05:30</TargetDate>
        <Remarks>aaa</Remarks>
      </Ongoing>
      <Ongoing diffgr:id="Ongoing6" msdata:rowOrder="4">
        <Timestamp>637551642023643329</Timestamp>
        <Task>Task10Task10Task10</Task>
        <Status>Reply</Status>
        <UCode>User8</UCode>
        <Name>User 8</Name>
        <CreateDate>2020-12-22T16:16:42.3653533+05:30</CreateDate>
        <TargetDate>2020-12-22T00:00:00+05:30</TargetDate>
        <Remarks>Reply Try 2</Remarks>
        <RemarksDate>2020-12-25T00:00:00+05:30</RemarksDate>
      </Ongoing>
      <Ongoing diffgr:id="Ongoing7" msdata:rowOrder="5">
        <Timestamp>637441642023644419</Timestamp>
        <Task>Task11</Task>
        <Status>Pending</Status>
        <UCode>User8</UCode>
        <Name>User 8</Name>
        <CreateDate>2020-12-01T16:16:42.3653533+05:30</CreateDate>
        <TargetDate>2020-12-31T00:00:00+05:30</TargetDate>
        <Remarks>Hello Completed </Remarks>
        <RemarksDate>2020-12-25T00:00:00+05:30</RemarksDate>
      </Ongoing>
      <Ongoing diffgr:id="Ongoing8" msdata:rowOrder="6">
        <Timestamp>637441642023643329</Timestamp>
        <Task>Task1</Task>
        <Status>Completed</Status>
        <UCode>User8</UCode>
        <Name>User 8</Name>
        <CreateDate>2020-12-21T16:16:42.3653533+05:30</CreateDate>
        <TargetDate>2020-12-21T00:00:00+05:30</TargetDate>
        <Remarks>Hello</Remarks>
        <RemarksDate>2020-12-25T00:00:00+05:30</RemarksDate>
      </Ongoing>
      <Ongoing diffgr:id="Ongoing9" msdata:rowOrder="7">
        <Timestamp>637444377373755673</Timestamp>
        <Task>Sample Task2 </Task>
        <Status>Unallocated</Status>
        <UCode />
        <Name />
        <CreateDate>2020-12-24T00:00:00+05:30</CreateDate>
      </Ongoing>
    </NewDataSet>
  </diffgr:diffgram>
</DataSet>