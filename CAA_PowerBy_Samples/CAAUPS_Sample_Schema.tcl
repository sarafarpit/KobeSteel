tcl;
  mql set env VERSION_NAME  'R421'
      set env(VERSION_NAME) "R421"
  mql set env VERSION_INTERNAL  '421'
      set env(VERSION_INTERNAL) "421"
eval {
	
	######################################################################################
	#
	#	Add CAAUPS GCO type
	#
	######################################################################################
	set sCADToLRDMapping_att "MCADInteg-CADToLRDMapping"
	set testType [mql list type CAAUPS-UPSGlobalConfig]
	if {[llength $testType] == 0} {
		puts "Add CAAUPS type starts..."
		mql add type CAAUPS-UPSGlobalConfig \
		  description 'Global Configuration of UPS Connector for CAA' \
		  derived MCADInteg-UPSGlobalConfig \
		  property version value $env(VERSION_INTERNAL) \
		  property application value ConnectorforCAA \
		  property 'installed date' value [clock format [clock second]] \
		  property installer value ENOVIAUPSIntegration;
		puts "Add CAAUPS type end"
	} else {
		puts "Type CAAUPS-UPSGlobalConfig already exists"
	}
	######################################################################################
	#
	#	Add CAAUPS GCO Business Object
	#
	######################################################################################
	

		set sWebFormValue "(DEFAULTVALUE)Properties\$UPSObjectProperties@(DEFAULTVALUE)Search\$UPSSearchForm"
		
		set sBusTypeMappingValue "assembly|VPMReference"
		append sBusTypeMappingValue "\n"
		append sBusTypeMappingValue "component|VPMReference"
		append sBusTypeMappingValue "\n"
		append sBusTypeMappingValue "cgrViewable|DerivedOutputEntity "
		append sBusTypeMappingValue "\n"
		append sBusTypeMappingValue "drawing|Drawing"
		append sBusTypeMappingValue "\n"
		append sBusTypeMappingValue "svgOutput|DerivedOutputEntity "
		append sBusTypeMappingValue "\n"
		append sBusTypeMappingValue "pdfOutput|DerivedOutputEntity "
		append sBusTypeMappingValue "\n"
		append sBusTypeMappingValue "caadocument|XCADNonPSBaseRepReference"

		
		set sRelMappingValue "assemblyComponent|to, VPMInstance"
		append sRelMappingValue "\n"
		append sRelMappingValue "drawing|to, XCADBaseDependency"
		append sRelMappingValue "\n"
		append sRelMappingValue "docdoclink|to, XCADBaseDependency"
		append sRelMappingValue "\n"
		append sRelMappingValue "dependencyPrimary|to, XCADBaseDependency"
		
		set sTypePolicyMapping "VPMReference|VPLM_SMB_Definition"
		append sTypePolicyMapping "\n"
		append sTypePolicyMapping "DerivedOutputEntity|VPLM_PRIVATE"
		append sTypePolicyMapping "\n"
		append sTypePolicyMapping "Drawing|VPLM_SMB_Definition"
		append sTypePolicyMapping "\n"
		append sTypePolicyMapping "XCADNonPSBaseRepReference|VPLM_SMB_Definition"
		
		set sTypeFormatMapping "pdfOutput|DerivedOutputEntity,PDF"
		
		set sCADToMxAttribMapping "assembly,sys:Part Number|VPMReference,V_Name"
		append sCADToMxAttribMapping "\n"
		append sCADToMxAttribMapping "component,sys:Part Number|VPMReference,V_Name"
		append sCADToMxAttribMapping "\n"
		append sCADToMxAttribMapping "assembly,sys:Description|VPMReference,V_description"
		append sCADToMxAttribMapping "\n"
		append sCADToMxAttribMapping "component,sys:Description|VPMReference,V_description"
		append sCADToMxAttribMapping "\n"
		append sCADToMxAttribMapping "caadocument,Title|XCADNonPSBaseRepReference,V_Name"
		
		set sMxToCadAttribMapping "VPMReference,V_Name|assembly,sys:Part Number"
		append sMxToCadAttribMapping "\n"
		append sMxToCadAttribMapping "VPMReference,V_Name|component,sys:Part Number"
		append sMxToCadAttribMapping "\n"
		append sMxToCadAttribMapping "VPMReference,V_description|assembly,sys:Description"
		append sMxToCadAttribMapping "\n"
		append sMxToCadAttribMapping "VPMReference,V_description|component,sys:Description"
        append sMxToCadAttribMapping "\n"
		append sMxToCadAttribMapping "XCADNonPSBaseRepReference,V_Name|caadocument,Title"

		set sTypeClassMapping "TYPE_ASSEMBLY_LIKE|assembly"
		append sTypeClassMapping "\n"
		append sTypeClassMapping "TYPE_COMPONENT_LIKE|component"
		append sTypeClassMapping "\n"
		append sTypeClassMapping "TYPE_DRAWING_LIKE|drawing"
		append sTypeClassMapping "\n"
		append sTypeClassMapping "TYPE_CAD_DOCUMENT_LIKE|caadocument"
		append sTypeClassMapping "\n"
		append sTypeClassMapping "TYPE_VISUALIZATION_LIKE|cgrViewable,svgOutput"
		append sTypeClassMapping "\n"
		append sTypeClassMapping "TYPE_DERIVED_OUTPUT_LIKE|pdfOutput"
		
		# set sTypeTemplateMapping "assembly|VPMReference Template"
		# append sTypeTemplateMapping "\n"
		# append sTypeTemplateMapping "component|VPMReference Template"
		# append sTypeTemplateMapping "\n"
		# append sTypeTemplateMapping "drawing|CATDrawing Template"

		set sDefaultTypePolicySettings "(HIDDEN)VPMReference|VPLM_SMB_Definition"

		set sTypeDerivedOutputMapping "component|cgrOutput"
		append sTypeDerivedOutputMapping "\n"
		append sTypeDerivedOutputMapping "drawing|svgOutput"
		append sTypeDerivedOutputMapping "\n"
		append sTypeDerivedOutputMapping "caadocument|pdfOutput"
		
		set sRelationShipClassMapping "assemblyComponent|REL_INSTANCE_LIKE"
		append sRelationShipClassMapping "\n"
		append sRelationShipClassMapping "drawing|REL_EXTERNAL_REFERENCE_LIKE"
		append sRelationShipClassMapping "\n"
		append sRelationShipClassMapping "docdoclink|REL_EXTERNAL_REFERENCE_LIKE"
		append sRelationShipClassMapping "\n"
		append sRelationShipClassMapping "dependencyPrimary|REL_PRIMARY_DEPENDENCY_LIKE"
	
		set sCADToLRDMapping "assembly|filename"
		append sCADToLRDMapping "\n"
		append sCADToLRDMapping "component|filename"
		append sCADToLRDMapping "\n"
		append sCADToLRDMapping "drawing|filename"
		append sCADToLRDMapping "\n"
		append sCADToLRDMapping "caadocument|filename"
	
	
	set testBo [mql temp query bus CAAUPS-UPSGlobalConfig CAAUPS TEAM]
	if {[llength $testBo] == 0} {

		
		puts "Add CAAUPS GCO  Business Object starts..."

		mql add bus CAAUPS-UPSGlobalConfig CAAUPS TEAM \
		  policy UPSConfigObjectPolicy \
		  description 'Global Configuration of Connector for CAAUPS' \
		  vault 'eService Administration' \
		  IEF-CheckUUIDConflict TRUE \
		  IEF-CheckObsoleteAcrossRevisions TRUE \
		  IEF-Pref-MCADInteg-DefaultTypePolicySettings $sDefaultTypePolicySettings \
		  IEF-AdminTables 'UPSOpenPageDetails|UPSSavePageDetails' \
		  IEF-Pref-IEF-DefaultConfigTables '(ENFORCED)Save\$Admin:UPSSavePageDetails@(ENFORCED)Open\$Admin:UPSOpenPageDetails' \
		  MCADInteg-BusTypeMapping $sBusTypeMappingValue \
		  MCADInteg-RelMapping $sRelMappingValue \
		  MCADInteg-TypePolicyMapping $sTypePolicyMapping \
		  MCADInteg-TypeFormatMapping $sTypeFormatMapping\
		  MCADInteg-MxToCADAttribMapping $sMxToCadAttribMapping \
		  MCADInteg-CADToMxAttribMapping $sCADToMxAttribMapping \
		  MCADInteg-RelationShipClassMapping $sRelationShipClassMapping \
		  MCADInteg-TypeDerivedOutputMapping  $sTypeDerivedOutputMapping \
		  MCADInteg-TypeClassMapping $sTypeClassMapping \
		  MCADInteg-CADToLRDMapping $sCADToLRDMapping \
		  MCADInteg-CADToMxRelAttribMapping "" \
		  MCADInteg-MxToCADRelAttribMapping "" \
		  IEF-Pref-MCADInteg-UseZipInCADFileOperations "FALSE" \
		  IEF-Pref-MCADInteg-UseZipInFileOperations "TRUE" \
		  IEF-Pref-MCADInteg-WarnForFileOverwrite "TRUE" \
		  IEF-Webforms "UPSObjectProperties|UPSSearchForm" \
		  IEF-Pref-IEF-DefaultWebforms $sWebFormValue \
		  MCADInteg-EnableHashcodeComputation TRUE;
		puts "Add CAAUPS GCO  Business Object ends"
	} else {
		puts "BO CAAUPS-UPSGlobalConfig CAAUPS TEAM already exists.. GCO is not being updated"
	}

	######################################################################################
	#
	#	Register CAAUPS GCO Business Object
	#
	######################################################################################
	set test [mql list prog ENOIEFRegistration]
	if {[llength $test] == 0} {
		puts "Registry cannot be done since ENOIEFRegistration program doesn't exist"
	} else {
		puts "Register CAAUPS GCO Business Object starts..."
		mql execute program ENOIEFRegistration -method registerIntegration CAAUPS CAAUPSAPP CAAUPS CAAUPS-UPSGlobalConfig TEAM FALSE FALSE;
		puts "Register CAAUPS GCO Business Object ends"
	}
}

