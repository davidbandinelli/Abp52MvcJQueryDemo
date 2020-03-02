(function () {
    $(function () {

        var _personService = abp.services.app.person;
        var _$modal = $('#PersonCreateModal');
        var _$form = _$modal.find('form');

        _$form.validate({
            rules: {
                EmailAddress: "required",
                Name: "required",
                Surname: "required"
            }
        });

        $('#RefreshButton').click(function () {
            refreshPersonList();
        });

        $('.delete-person').click(function () {
            var personId = $(this).attr("data-person-id");
            var personName = $(this).attr('data-person-name');
            //alert('delete, id=' + personId + ',name=' + personName);
            deletePerson(personId, personName);
        });

        $('.edit-person').click(function (e) {
            var personId = $(this).attr("data-person-id");

            e.preventDefault();
            abp.ajax({
                url: abp.appPath + 'Phonebook/EditPersonModal?personId=' + personId,
                type: 'POST',
                dataType: 'html',
                success: function (content) {
                    $('#PersonEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var person = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

            abp.ui.setBusy(_$modal);
            _personService.createPerson(person).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new person!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshPersonList() {
            location.reload(true); //reload page to see new person!
        }

        function deletePerson(personId, personName) {
            abp.message.confirm(
                'Delete person "' + personName + '"?',
                'DeletePerson',
                function (isConfirmed) {
                    if (isConfirmed) {
                        _personService.deletePerson({
                            id: personId
                        }).done(function () {
                            refreshPersonList();
                        });
                    }
                }
            );
        }
    });
})();
