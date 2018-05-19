<script type="text/javascript">
    function OnBatchEditStartEditing(s, e) {
        ToggleButtons(true);
    }
    function OnBatchEditEndEditing(s, e) {
        window.setTimeout(function () {
            if (!s.batchEditApi.HasChanges())
                ToggleButtons(false);
        }, 0);
    }
    function ToggleButtons(enabled) {
        btnUpdate.SetEnabled(enabled);
        btnCancel.SetEnabled(enabled);
    }
    function OnUpdateClick(s, e) {
        GridView.UpdateEdit();
        ToggleButtons(false);
    }
    function OnCancelClick(s, e) {
        GridView.CancelEdit();
        ToggleButtons(false);
    }

    function OnCustomButtonClick(s, e) {
        if (e.buttonID == "deleteButton") {
            s.DeleteRow(e.visibleIndex);
            ToggleButtons(true);
        }
    }
    function OnEndCallback(s, e) {
        window.setTimeout(function () {
            if (!s.batchEditApi.HasChanges())
                ToggleButtons(false);
        }, 0);
    }
</script>
@Html.Action("GridViewPartial")
<br />
@Html.DevExpress().Button(Sub(settings)
		settings.Name = "btnUpdate"
		settings.Text = "Update"
		settings.ClientEnabled = False
		settings.ClientSideEvents.Click = "OnUpdateClick"
	End Sub).GetHtml() 
@Html.DevExpress().Button(Sub(settings)
		settings.Name = "btnCancel"
		settings.Text = "Cancel"
		settings.ClientEnabled = False
		settings.ClientSideEvents.Click = "OnCancelClick"
End Sub).GetHtml()