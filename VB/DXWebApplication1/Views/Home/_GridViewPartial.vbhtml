@Code
Dim grid = Html.DevExpress().GridView(Sub(settings)
		settings.Name = "GridView"
		settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewPartial"}
		settings.SettingsEditing.BatchUpdateRouteValues = New With {Key .Controller = "Home", Key .Action = "BatchUpdatePartial"}
		settings.SettingsEditing.Mode = GridViewEditingMode.Batch
		settings.CommandColumn.Visible = True
		settings.CommandColumn.ShowNewButtonInHeader = True
		Dim customButton As New GridViewCommandColumnCustomButton()
		customButton.Text = "Delete"
		customButton.ID = "deleteButton"
		settings.CommandColumn.CustomButtons.Add(customButton)
		settings.KeyFieldName = "ID"
		settings.Columns.Add("C1")
		settings.Columns.Add(Sub(column)
			column.FieldName = "C2"
			column.ColumnType = MVCxGridViewColumnType.SpinEdit
		End Sub)
		settings.Columns.Add("C3")
		settings.Columns.Add(Sub(column)
			column.FieldName = "C4"
			column.ColumnType = MVCxGridViewColumnType.CheckBox
		End Sub)
		settings.Columns.Add(Sub(column)
			column.FieldName = "C5"
			column.ColumnType = MVCxGridViewColumnType.DateEdit
		End Sub)
		settings.CellEditorInitialize = Sub(s, e)
			Dim editor As ASPxEdit = CType(e.Editor, ASPxEdit)
			editor.ValidationSettings.Display = Display.Dynamic
		End Sub
		settings.Settings.ShowStatusBar = GridViewStatusBarMode.Hidden
		settings.ClientSideEvents.BatchEditStartEditing = "OnBatchEditStartEditing"
		settings.ClientSideEvents.BatchEditEndEditing = "OnBatchEditEndEditing"
		settings.ClientSideEvents.CustomButtonClick = "OnCustomButtonClick"
		settings.ClientSideEvents.EndCallback = "OnEndCallback"
	End Sub)
End Code
@grid.Bind(Model).GetHtml()